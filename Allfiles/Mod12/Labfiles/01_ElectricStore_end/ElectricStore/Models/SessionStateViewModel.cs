using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricStore.Models
{
    public class SessionStateViewModel
    {
        public string CustomerName { get; set; }
        public List<Product> SelectedProducts { get; set; }
    }
}
