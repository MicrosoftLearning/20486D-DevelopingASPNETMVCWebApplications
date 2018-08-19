using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Server.Models
{
    [DataContract(Namespace = "")]
    public class RestaurantBranch
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [StringLength(20)]
        public string Street { get; set; }

        [DataMember]
        [StringLength(20)]
        public string City { get; set; }

        [DataMember]
        public bool Open { get; set; }

        [DataMember]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
