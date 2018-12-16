using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Client.Models
{
    public class RestaurantBranch
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Street { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        public bool Open { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<OrderTable> OrderTables { get; set; }
    }
}
