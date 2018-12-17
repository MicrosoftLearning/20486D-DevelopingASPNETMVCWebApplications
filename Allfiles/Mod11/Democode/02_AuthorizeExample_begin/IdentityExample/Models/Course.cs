using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Course Name")]
        public string Name { get; set; }
    }
}
