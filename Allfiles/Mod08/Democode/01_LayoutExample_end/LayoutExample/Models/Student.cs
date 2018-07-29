using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutExample.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "BirthDate")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        [Display(Name = "Course")]
        public string Course { get; set; }

        [Display(Name = "Date of commencement of studies")]
        [DataType(DataType.Date)]
        public DateTime StartedUniversityDate { get; set; }
    }
}
