using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCart.Models
{
    public class UserType
    {
        [Key]
        public int UserId { get; set; }
        public int Designation { get; set; }
        public ICollection<Users> Users { get; set; }

    }
}