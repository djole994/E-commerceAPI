using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace E_commerce.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(10)]
        public string Currency { get; set; } = "EUR";

        [Required]
        [MaxLength(20)]
        public string PaymentMethod { get; set; } = "Stripe"; // koriste se često, PROVJERITI! "Stripe", "PayPal"
        public string Status { get; set; } = "Initiated"; //Default status, u procesu placanja
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Transaction? Transaction { get; set; }
    }

}
