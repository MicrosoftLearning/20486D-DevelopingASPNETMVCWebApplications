using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cupcakes.Models
{
    public class Bakery
    {
        //[Key]
        public int BakeryId { get; set; }

        //[StringLength(50, MinimumLength = 4)]
        //[Required]
        public string BakeryName { get; set; }

        //[Range(1,40)]
        public int Quantity { get; set; }

        //[StringLength(50, MinimumLength = 4)]
        //[Required]
        public string Address { get; set; }

        public virtual ICollection<Cupcake> Cupcakes { get; set; }
    }
}
