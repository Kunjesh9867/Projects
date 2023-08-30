using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Stripe;
using Stripe.Checkout;

using GroovyGoods.Data;
using GroovyGoods.Models;

namespace MachoMeals.Controllers
{
    public class ShopController : Controller
    {
        //Property for our database conection
        private ApplicationDbContext _context;
        private IConfiguration _configuration;

        //Constructor
        public ShopController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            var  Artist = await _context.Artists
                .OrderBy(artist => artist.Name)
                .ToListAsync();

            return View( Artist);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var artistWithProducts = await _context.Artists
                .Include(artist => artist.products)
                .FirstOrDefaultAsync(artist => artist.Id == id);

            return View(artistWithProducts);

        }
        public async Task<IActionResult> ProductDetails(int? id)

        {
            var product = await _context.Products
                .Include(product => product.Artist)
                .FirstOrDefaultAsync (product => product.Id == id);
            return View(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            //get our logged in user
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // attempt to get the user's cart

            var cart = await _context.Carts
                .FirstOrDefaultAsync(cart => cart.UserId == userId && cart.Active == true);
            
            //if no cart, make a cart
            if(cart == null)
            {
                cart = new GroovyGoods.Models.Cart { UserId = userId };
                await _context.AddAsync(cart);
                await _context.SaveChangesAsync();
            }
            //find our products
            var product = await _context.Products
                .FirstOrDefaultAsync(product => product.Id == productId);

            ///GTFO if no product
           
            if(product == null)
            {
                return NotFound();
            }

            // create a cart item
            var cartItem = new GroovyGoods.Models.CartItem
            {
                Cart = cart,
                Product = product,
                Quantity = quantity,
                Price = product.Price,
            };

            //if valid, do all the goodness

            if(ModelState.IsValid)
            {
                await _context.AddAsync(cartItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("ViewMyCart");
            }

            //otherwise GTFO
            return NotFound();
        }
        [Authorize]
        public async Task<IActionResult> ViewMyCart()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            var cart = await _context.Carts
                .Include(cart => cart.User)
                .Include(cart => cart.CartItems)
                .ThenInclude(cartItem => cartItem.Product)
                .FirstOrDefaultAsync(cart => cart.UserId == userId && cart.Active == true);

            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteCartItem(int cartItemId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var cart = await _context.Carts
                  .FirstOrDefaultAsync(cart => cart.UserId == userId && cart.Active == true);

            if (cart == null) return NotFound();
            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(cartItem => cartItem.Cart == cart && cartItem.Id == cartItemId);
            if (cartItem != null)
            { 
                _context.CartItems.Remove(cartItem);    
                await _context.SaveChangesAsync();

                return RedirectToAction("ViewMyCart");
            }
            return NotFound();
        }
        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var cart = await _context.Carts
                .Include(cart => cart.User)
                .Include(cart => cart.CartItems)
                .ThenInclude(cartItem => cartItem.Product)
                .FirstOrDefaultAsync(cart => cart.UserId == userId && cart.Active == true);

            var order = new GroovyGoods.Models.Order
            {
                UserId = userId,
                Cart = cart,
                Total = cart.CartItems.Sum(cartItem => cartItem.Quantity * cartItem.Price),
                ShippingAddress = "",
                PaymentMethod = GroovyGoods.Models.PaymentMethods.VISA,
                
                

            };

            ViewData["PaymentMethod"] = new SelectList(Enum.GetValues(typeof(PaymentMethods)));
            return View(order);

        }

        [Authorize]
        [HttpPost]

        public async Task<IActionResult> Payment(string shippingAddress, PaymentMethods paymentMethod)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var cart = await _context.Carts
                .Include(cart => cart.CartItems)
                .FirstOrDefaultAsync(cart => cart.UserId == userId && cart.Active == true);

            if (cart == null) return NotFound();

            //add order data to the session
            HttpContext.Session.SetString("ShippingAddress", shippingAddress); 
            HttpContext.Session.SetString("PaymentMethod", paymentMethod.ToString());

            //set Stripe API key
            StripeConfiguration.ApiKey = _configuration.GetSection("Stripe")["SecretKey"];

            //Create our Stripe options
            var options = new Stripe.Checkout.SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(cart.CartItems.Sum(cartItem => cartItem.Quantity * cartItem.Price) * 100),
                            Currency = "cad",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "MachoMeals Purchase",

                            },
                           
                        },
                         Quantity = 1,
                    },
                   
                },
                 PaymentMethodTypes = new List<string>
                 {
                     "card"
                 },
                 Mode = "payment",
                 SuccessUrl = "https://" + Request.Host + "/Shop/SaveOrder",
                 CancelUrl = "https://" + Request.Host + "/Shop/ViewMyCart",
            };

            var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public async Task<IActionResult> SaveOrder()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var cart = await _context.Carts
                .Include(cart => cart.CartItems)
                .FirstOrDefaultAsync(cart => cart.UserId == userId && cart.Active == true);

            //Get our data out of the session
            var paymentMethod = HttpContext.Session.GetString("PaymentMethod");
            var shippingAddress = HttpContext.Session.GetString("ShippingAddress");

            var order = new Order
            {
                UserId = userId,
                Cart = cart,
                Total = cart.CartItems.Sum(carItem => carItem.Quantity * carItem.Price),
                ShippingAddress = shippingAddress,
                PaymentMethod = (PaymentMethods)Enum.Parse(typeof(PaymentMethods),paymentMethod),
                PaymentReceived = true

            };
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();

            cart.Active = false;
            _context.Update(cart);
            await _context.SaveChangesAsync();

            return RedirectToAction("OrderDetails", new { id = order.Id });


        }

        [Authorize]
        public async Task<IActionResult> OrderDetails(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var order = await _context.Orders
                .Include(order => order.User)
                .Include(order => order.Cart)
                .ThenInclude(cart => cart.CartItems)
                .ThenInclude(cartItem => cartItem.Product)
                .FirstOrDefaultAsync(order => order.UserId == userId && order.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }
        [Authorize]
        public async Task<IActionResult> Orders()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var orders = await _context.Orders
                .OrderByDescending(order => order.Id)
                .Where(order => order.UserId == userId)
                .ToListAsync();

            if (orders == null) return NotFound();

            return View(orders);

        }
    }
}
