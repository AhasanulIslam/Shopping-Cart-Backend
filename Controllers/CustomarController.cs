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
   public class CustomarController : ControllerBase
    {
         private readonly DataContext _context;
        public CustomarController(DataContext context)
        {
            _context = context;
            
        }

       [AllowAnonymous]
        [HttpGet("{customar}/{name}/{new}")]
        public async Task<IActionResult> GetCostomars(int id)
        {
              var customars = await _context.Customars.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT * FROM Customars").ToListAsync();

            return Ok(customars);

        }
         [AllowAnonymous]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostCustomar([FromBody]CustomarDto customar)
        {
            //   var transactions = await _context.Transactions.
            //  FromSqlRaw("insert into transactions where  Debit = {0}, credit = {1}, date = {2}, AccountTitle = {3}",transaction.Debit, transaction.Credit, transaction.Date, transaction.AccountTitle  ).ToListAsync();
            // //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();
            // _context.SaveChanges();

            // var number = Int16.Parse(room.Number);
            // var capacity = Int16.Parse(room.Capacity);

            var customars = new Customar
            {
                CustomarName = customar.CustomarName,
                Password = customar.Password,
                Email = customar.Email
            };
            await _context.Customars.AddAsync(customars);//this doesnt change in our database
            await _context.SaveChangesAsync();

            return Ok(customars);
        }

         [AllowAnonymous]
        [HttpGet("{name}/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var Id = Convert.ToInt16(id);
            var user = _context.Customars.FirstOrDefault(x => x.CustomarId == Id);
            _context.Customars.Remove(user);
            // _context.Staffs.RemoveRange
            //     (_context.Staffs.Where(x => x.StaffId == Id));
            _context.SaveChanges();

            return Ok(user);

        }
        [AllowAnonymous]
        [HttpGet("{test}")]
        public IActionResult Test()
        {
            return Ok("su");
        }

    }
}