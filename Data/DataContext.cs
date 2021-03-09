using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Models;

namespace OnlineShoppingCart.Data
{
   public class DataContext : DbContext

    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

            public DbSet<Product> Products {get; set; }
            public DbSet<Users> User {get; set;}  
            public DbSet<Order> Oders { get; set; }
            public DbSet<Cart> Carts { get; set; }
            public DbSet<ProductManager> ProductManagers { get; set; }
            public DbSet<UserType> UserTypes { get; set; }
            public DbSet<Customar> Customars { get; set; }



    }
}