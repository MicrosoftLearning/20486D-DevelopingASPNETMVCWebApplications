using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string PhotoFileName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        [Display(Name = "Last retrieved on")]
        [NotMapped]
        public DateTime LoadedFromDatabase { get; set; }

        [InverseProperty("Product")]
        public virtual List<CustomersProducts> CustomerProducts { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        public MenuCategory MenuCategory { get; set; }
    }
}
