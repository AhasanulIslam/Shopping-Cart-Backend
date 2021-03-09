namespace OnlineShoppingCart.Models
{
    public class ProductManager
    {

        public int ProductManagerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Access_Level { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Token { get; set; }

    }
}
   