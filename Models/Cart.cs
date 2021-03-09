using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int TotalCount { get; set; }
        public int? OrderId { get; set; }
        [ForeignKey("OrderId")]

        public Order Order { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        
        public Product Product { get; set; }
    }
}