using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart.Models
{
    public class Users
    {
    
        [Key]
        public int BossID { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname {get; set; }
        public string Contrct {get; set; }
        public string Password  { get; set; }
        public ICollection<Order> Order { get; set; }

         public int? UserId { get; set; }
        [ForeignKey("UserId")]

        public UserType UserType { get; set; }


        
        

    }
}