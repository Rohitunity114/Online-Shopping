using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Shopping.Models
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        public int Userid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public string ProfileImage { get; set; }
        public string City { get; set; }
        public string State { get; set; }


    }
}