using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExample.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "Full Name:")]
        public string FullName { get; set; }

        [Display(Name = "Email Address:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Birthdate:")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
