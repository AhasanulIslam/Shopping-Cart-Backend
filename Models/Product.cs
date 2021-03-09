using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCart.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int ProductNumber { get; set; }
        public ICollection<Cart> Cart { get; set; }


    }
}