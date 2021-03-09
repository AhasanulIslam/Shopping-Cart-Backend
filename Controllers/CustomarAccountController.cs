using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Data;
using OnlineShoppingCart.Dtos;
using OnlineShoppingCart.Helpers;
using OnlineShoppingCart.Models;

namespace OnlineShoppingCart.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomarAccountController : ControllerBase
    {
        private readonly ICustomarService _userService;
        // private readonly IMapper _mapper;
         private readonly DataContext _context;

        public CustomarAccountController(ICustomarService userService,DataContext context) 
        {
            _userService = userService;
            _context = context;

        }
        
       
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if(user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);

        }

        [AllowAnonymous]
        [HttpPost("{register}/{Stu}")]
        public async Task<IActionResult> Register([FromBody]CustomarForDto userForRegisterDto)
        {

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _userService.UserExist(userForRegisterDto.Username))
                ModelState.AddModelError("Username", "Username already exist");


            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var userToCreate = new Customar
            {
                CustomarName = userForRegisterDto.Username,
                Email = userForRegisterDto.Email
            // Access_Level = userForRegisterDto.Access
            };

            var createUser = await _userService.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
        
        // [AllowAnonymous]
        // [HttpGet("{inventores}")]
        // public async Task<IActionResult> GetInventoriers(int id)
        // {
        //       var inventores = await _context.Invertories.
        //     //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
        //     FromSqlRaw("SELECT * FROM Invertories").ToListAsync();

        //     return Ok(inventores);

        // }
        //  [AllowAnonymous]
        // [HttpPost("{id}")]
        // public async Task<IActionResult> PostInvertory([FromBody]InventoryDto inventory)
        // {
        //     //   var transactions = await _context.Transactions.
        //     //  FromSqlRaw("insert into transactions where  Debit = {0}, credit = {1}, date = {2}, AccountTitle = {3}",transaction.Debit, transaction.Credit, transaction.Date, transaction.AccountTitle  ).ToListAsync();
        //     // //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();
        //     // _context.SaveChanges();

        //     // var number = Int16.Parse(room.Number);
        //     // var capacity = Int16.Parse(room.Capacity);

        //     var inventores = new Invertory
        //     {
        //         Status = inventory.Status,
        //         Date = inventory.Date
        //     };
        //     await _context.Invertories.AddAsync(inventores);//this doesnt change in our database
        //     await _context.SaveChangesAsync();

        //     return Ok(inventores);
        // }

         [AllowAnonymous]
        [HttpGet("{invertory}/{id}")]
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
        [HttpGet("{staffs}/{new}/{user}")]
        public async Task<IActionResult> GetCustomars(int id)
        {
              var managers = await _context.Customars.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT * FROM Customars").ToListAsync();

            return Ok(managers);

        }
    }
}