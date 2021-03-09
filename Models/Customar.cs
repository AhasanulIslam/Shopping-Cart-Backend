using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCart.Models
{
    public class Customar
    {
        [Key]
        public int  CustomarId { get; set; }
        public string CustomarName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Token { get; set; }
        

    }
}