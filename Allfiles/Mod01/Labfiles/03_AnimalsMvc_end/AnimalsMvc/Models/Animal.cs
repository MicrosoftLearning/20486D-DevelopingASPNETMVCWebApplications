using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsMvc.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string UniqueInformation { get; set; }
        public String Category { get; set; }
    }
}
