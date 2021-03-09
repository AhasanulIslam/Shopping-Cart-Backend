using System.Threading.Tasks;
using OnlineShoppingCart.Models;

namespace OnlineShoppingCart.Helpers
{
    public interface IUserservice
    {
        Task<ProductManager> Register(ProductManager user, string password);
        Task<ProductManager> Authenticate(string username, string password);
        Task<bool> UserExist(string username);
    }
}