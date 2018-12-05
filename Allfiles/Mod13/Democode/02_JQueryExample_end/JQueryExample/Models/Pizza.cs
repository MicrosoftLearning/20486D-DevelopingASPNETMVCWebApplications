using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JQueryExample.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [DataType(DataType.Currency)]
        public float Price { get; set; }

        public string Toppings { get; set; }
    }
}
