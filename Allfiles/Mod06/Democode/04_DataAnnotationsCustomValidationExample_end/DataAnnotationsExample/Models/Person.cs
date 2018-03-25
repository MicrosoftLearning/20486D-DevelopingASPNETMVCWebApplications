using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExample.Validators;

namespace DataAnnotationsExample.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }

        [AgeValidation(2000)]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [StringLength(10)]
        public string Description { get; set; }
    }
}
