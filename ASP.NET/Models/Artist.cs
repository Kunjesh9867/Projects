using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GroovyGoods.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required(),MaxLength(255)]
        public string Name { get; set; }
        [Required(), MaxLength(1500)]
        public string Description { get; set; }
        [Required(), MaxLength(255)]


        [Display(Name = "Favorite Sauce")]
        public string Genre { get; set; }
        [Required(), MaxLength(255)]
        [Display(Name=" URL")]
        public string Website { get; set; }
        [Required()]
        [Display(Name = "Available Quantity")]

        public int YearsActive { get; set; }



        [Display(Name = "Discount Until")]
        [Required()]

        public DateTime DateOfBirth { get; set; }

        public List<Product>? products { get; set; }




    }
}
