using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExample.Validator;

namespace DataAnnotationsExample.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }

        [Display(Name = "Birthdate:")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Are you a university student?")]
        [InUniversityValidation]
        public bool UniversityStudent { get; set; }
    }
}
