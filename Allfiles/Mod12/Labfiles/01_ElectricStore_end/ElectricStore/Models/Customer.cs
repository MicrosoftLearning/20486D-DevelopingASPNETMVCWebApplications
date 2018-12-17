using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricStore.Models
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
        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }

        [Display(Name = "Phone"), DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your adress")]
        public string Address { get; set; }

        public virtual List<CustomersProducts> CustomerProducts { get; set; }

        [NotMapped]
		[Display(Name = "Products List")]
        public List<int> SelectedProductsList { get; set; }
    }
}
