using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamCompany.Models
{
    public class IceCreamFlavorsCustomers
    {
        public int IceCreamId { get; set; }
        public IceCream IceCream { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
