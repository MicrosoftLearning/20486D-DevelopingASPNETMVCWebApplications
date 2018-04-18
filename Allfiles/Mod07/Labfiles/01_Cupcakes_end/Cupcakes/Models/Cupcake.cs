using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cupcakes.Models
{
    public class Cupcake
    {
        public int CupcakeId { get; set; }
        public CupcakeType CupcakeType { get; set; }
        public string Description { get; set; }
        public bool GlutenFree { get; set; }
        public float Price { get; set; }

        public int BakeryId { get; set; }
        public virtual Bakery Bakery { get; set; }
    }
}
