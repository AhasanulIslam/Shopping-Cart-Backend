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
   public class CartController : ControllerBase
    {
         private readonly DataContext _context;
        public CartController(DataContext context)
        {
            _context = context;
            
        }

       [AllowAnonymous]
        [HttpGet("{cart}/{name}/{new}")]
        public async Task<IActionResult> GetCart(int id)
        {
              var cart = await _context.Carts.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT * FROM Carts").ToListAsync();

            return Ok(cart);

        }
         [AllowAnonymous]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostCart([FromBody]CartDto cart)
        {
            //   var transactions = await _context.Transactions.
            //  FromSqlRaw("insert into transactions where  Debit = {0}, credit = {1}, date = {2}, AccountTitle = {3}",transaction.Debit, transaction.Credit, transaction.Date, transaction.AccountTitle  ).ToListAsync();
            // //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();
            // _context.SaveChanges();

            // var number = Int16.Parse(room.Number);
            // var capacity = Int16.Parse(room.Capacity);

            var carts = new Cart
            {
                OrderId = cart.OrderId,
                TotalCount = cart.TotalCount

            };
            await _context.Carts.AddAsync(carts);//this doesnt change in our database
            await _context.SaveChangesAsync();

            return Ok(carts);
        }

         [AllowAnonymous]
        [HttpGet("{name}/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var Id = Convert.ToInt16(id);
            var cart = _context.Carts.FirstOrDefault(x => x.CartId == Id);
            _context.Carts.Remove(cart);
            // _context.Staffs.RemoveRange
            //     (_context.Staffs.Where(x => x.StaffId == Id));
            _context.SaveChanges();

            return Ok(cart);

        }
        

    }
}