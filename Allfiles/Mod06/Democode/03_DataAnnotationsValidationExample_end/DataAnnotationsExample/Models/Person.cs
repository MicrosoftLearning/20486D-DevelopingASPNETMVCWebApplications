using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExample.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }

        [Range(15, 50)]
        [Display(Name = "Age:")]
        public int Age { get; set; }

        [StringLength(10)]
        [Display(Name = "Description:")]
        public string Description { get; set; }
    }
}
