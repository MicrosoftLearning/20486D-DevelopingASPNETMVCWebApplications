using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cupcakes.Models
{
    public class Cupcake
    {
        //[Key]
        public int CupcakeId { get; set; }

        //[Required]
        public CupcakeType CupcakeType { get; set; }

       // [Required]
        public string Description { get; set; }

       // [Required]
        public bool GlutenFree { get; set; }

        //[Range(1, 15)]
        //[DataType(DataType.Currency)]
        public double Price { get; set; }

        //[Required]
        [NotMapped]
        public IFormFile PhotoAvatar { get; set; }

        public string ImageName { get; set; }

        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }

        public int BakeryId { get; set; }

        public virtual Bakery Bakery { get; set; }
    }
}
