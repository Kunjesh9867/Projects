using System.ComponentModel.DataAnnotations;

namespace GroovyGoods.Models
{
    public class Product
    {

        public int Id { get; set; }
            
        [Required()]
       
        public int ArtistId { get; set; }
        [Required(), MaxLength(300)]

        [Display(Name = "Artist")]
        public string Name { get; set; }
        [Required(), MaxLength(2000)]
        public string Description { get; set; }

        [Required()]
        public decimal Price { get; set; }
        [Required()]
        public string Image_URL { get; set; }
        [Required()]
        public DateTime Released { get; set; }
        [Required()]
        public int Quantity { get; set; }

        public Artist? Artist { get; set; }  
    }
}
