using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeStoreApi.Models
{
    public class CakeStore
    {
        public int Id { get; set; }
        public string CakeType { get; set; }
        public int Quantity { get; set; }
    }
}
