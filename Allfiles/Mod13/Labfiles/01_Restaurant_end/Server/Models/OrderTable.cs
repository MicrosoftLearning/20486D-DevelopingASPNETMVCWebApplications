using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class OrderTable
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string FistName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReservationTime { get; set; }

        [Range(1, 20)]
        public int dinnerGuests { get; set; }
    }
}
