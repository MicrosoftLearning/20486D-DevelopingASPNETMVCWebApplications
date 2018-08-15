using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class RestaurantBranch
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public bool Open { get; set; }
        public string PhoneNumber { get; set; }
    }
}
