using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cupcakes.Models
{
    public class Bakery
    {
        public int BakeryId { get; set; }
        public string BakeryName { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Cupcake> Cupcakes { get; set; }
    }
}
