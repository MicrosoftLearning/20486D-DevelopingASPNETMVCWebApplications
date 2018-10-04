using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        [Range(1, 1500)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Picture")]
        [MaxLength]
        public string PhotoFileName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public virtual List<CustomersProducts> CustomerProducts { get; set; }
    }
}
