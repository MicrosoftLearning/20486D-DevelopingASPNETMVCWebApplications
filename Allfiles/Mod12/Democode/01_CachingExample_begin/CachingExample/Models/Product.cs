using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace CachingExample.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float BasePrice { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        [Display(Name = "Price")]
        public string FormattedPrice
        {
            get
            {
                return BasePrice.ToString($"C2", CultureInfo.GetCultureInfo("en-US"));
            }
        }
    }
}
