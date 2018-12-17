using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooSite.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        [Display(Name = "Phone"), DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter your phone")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your adress")]
        public string Address { get; set; }
    }
}
