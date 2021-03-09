using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int Add { get; set; }
        public int Cancle { get; set; }
        public int Delivery { get; set; }
        
        public ICollection<Cart> Cart { get; set; }
          public int? UserId { get; set; }
        [ForeignKey("UserId")]

        public Users Users { get; set; }

    }
}