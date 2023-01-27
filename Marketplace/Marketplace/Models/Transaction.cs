using System.ComponentModel.DataAnnotations;


namespace Marketplace.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int productId { get; set; }
        public int count { get; set; }
        public double price { get; set; }
        public int buyerId { get; set; }
    }
}
