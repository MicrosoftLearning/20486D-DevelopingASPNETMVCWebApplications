using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ShirtStoreWebsite.Models
{
    public class Shirt
    {
        public int Id { get; set; }
        [Display(Name = "Size"), Required]
        public ShirtSize Size { get; set; }
        [Display(Name = "Color"), Required]
        public ShirtColor Color { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public float Tax { get; set; }

        public string GetFormattedTaxedPrice()
        {
            return Price.ToString($"C2", CultureInfo.GetCultureInfo("en-US"));
        }
    }
}
