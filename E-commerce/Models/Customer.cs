using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)] 
        public string ShippingAddress { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string BillingAddress { get; set; } = string.Empty; //neki standard, da se poklopi sa adresom sa kartice!!

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}
