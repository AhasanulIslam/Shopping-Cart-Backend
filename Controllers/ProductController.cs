using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Data;
using OnlineShoppingCart.Dtos;
using OnlineShoppingCart.Models;

namespace OnlineShoppingCart.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
   public class ProductController : ControllerBase
    {
         private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
            
        }

       [AllowAnonymous]
        [HttpGet("{product}/{name}/{new}")]
        public async Task<IActionResult> GetProducts(int id)
        {
              var customars = await _context.Products.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT * FROM Products").ToListAsync();

            return Ok(customars);

        }
         [AllowAnonymous]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostProduct([FromBody]ProductDto product)
        {
            //   var transactions = await _context.Transactions.
            //  FromSqlRaw("insert into transactions where  Debit = {0}, credit = {1}, date = {2}, AccountTitle = {3}",transaction.Debit, transaction.Credit, transaction.Date, transaction.AccountTitle  ).ToListAsync();
            // //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();
            // _context.SaveChanges();

            // var number = Int16.Parse(room.Number);
            // var capacity = Int16.Parse(room.Capacity);

            var products = new Product
            {
                ImageUrl = product.ImageUrl,
                ProductName = product.ProductName,
                Price = product.Price,
                ProductNumber = product.ProductNumber

            };
            await _context.Products.AddAsync(products);//this doesnt change in our database
            await _context.SaveChangesAsync();

            return Ok(products);
        }

         [AllowAnonymous]
        [HttpGet("{name}/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var Id = Convert.ToInt16(id);
            var product = _context.Products.FirstOrDefault(x => x.ProductId == Id);
            _context.Products.Remove(product);
            // _context.Staffs.RemoveRange
            //     (_context.Staffs.Where(x => x.StaffId == Id));
            _context.SaveChanges();

            return Ok(product);

        }
        

    }
}