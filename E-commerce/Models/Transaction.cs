using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string ExternalTransactionId { get; set; } = string.Empty; //eksterni id koji šalje neki payment sistem

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Approved"; // ili "Declined", "Pending itd.

        [MaxLength(10)]
        public string ResponseCode { get; set; } = string.Empty; //standard, ako payment bude neuspjesan "200" "402 - failed"

        [MaxLength(255)]
        public string Message { get; set; } = string.Empty;
    }

}
