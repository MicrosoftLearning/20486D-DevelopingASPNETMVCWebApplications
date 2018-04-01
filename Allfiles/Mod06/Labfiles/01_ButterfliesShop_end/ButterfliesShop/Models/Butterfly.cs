using ButterfliesShop.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesShop.Models
{
    public class Butterfly
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the butterfly name")]
        [Display(Name = "Common Name:")]
        public string CommonName { get; set; }

        [Required(ErrorMessage = "Please select the butterfly family")]
        [Display(Name = "Butterfly Family:")]
        public Family ButterflyFamily { get; set; }

        [Display(Name = "Amount in the shop:")]
        [AmountValidation(10)]
        public int AmountInShop { get; set; }

        [Display(Name = "Characteristics:")]
        [StringLength(30)]
        public string Characteristics { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Updated on:")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime CreatedDate { get; set; }

        [Display(Name ="Picture")]
        [MaxLength]
        public string PhotoFileName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
