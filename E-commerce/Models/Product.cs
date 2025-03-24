using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Brand { get; set; } = string.Empty;


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }    // Originalna cijena, postavljena na dvije decimale, RAZMISLITI O 4 decimale

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountPrice { get; set; }     // Snižena cijena 

        public bool IsDiscounted => DiscountPrice.HasValue && DiscountPrice.Value < Price; //ako postoji DiscountPrice i manji je od price, onda postoji snizenje

        [MaxLength(255)]
        public string ImageUrl { get; set; } = string.Empty;
        

        public int StockQuantity { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }

}
