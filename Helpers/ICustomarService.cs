using System.Threading.Tasks;
using OnlineShoppingCart.Models;

namespace OnlineShoppingCart.Helpers
{
    public interface ICustomarService
    {
        Task<Customar> Register(Customar user, string password);
        Task<Customar> Authenticate(string username, string password);
        Task<bool> UserExist(string username);
    }
}