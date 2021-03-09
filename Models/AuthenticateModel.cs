using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCart.Models
{
   
    public class AuthenticateModel
    {
        
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}