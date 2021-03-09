using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCart.Dtos
{
    public class CustomarForDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength=4,
        ErrorMessage = "You must specify a password between 4 and 8 character")]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        
    } 
}