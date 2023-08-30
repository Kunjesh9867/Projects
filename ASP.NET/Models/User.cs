using Microsoft.AspNetCore.Identity;
namespace GroovyGoods.Models
{
    public class User: IdentityUser
    {
        public List<Cart>? Cart {get; set;} 

        public List<Order>? Order { get; set;}
    }
}
