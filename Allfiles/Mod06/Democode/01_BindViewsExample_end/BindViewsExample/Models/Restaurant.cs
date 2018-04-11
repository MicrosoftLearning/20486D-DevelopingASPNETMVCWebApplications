using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BindViewsExample.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Open { get; set; }
        public string Speciality { get; set; }
        public int Review { get; set; }
    }
}
