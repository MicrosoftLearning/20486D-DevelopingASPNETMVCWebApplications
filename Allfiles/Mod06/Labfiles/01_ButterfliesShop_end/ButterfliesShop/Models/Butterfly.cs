using ButterfliesShop.Validators;
using Microsoft.AspNetCore.Http;
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
        public Family? ButterflyFamily { get; set; }

        [Required(ErrorMessage = "Please select the butterfly quantity")]
        [Display(Name = "Butterflies Quantity:")]
        [MaxButterflyQuantityValidation(50)]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Please type the characteristics")]
        [Display(Name = "Characteristics:")]
        [StringLength(30)]
        public string Characteristics { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Updated on:")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Please select the butterflies picture")]
        [Display(Name = "Butterflies Picture:")]
        public IFormFile PhotoAvatar { get; set; }

        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }
    }
}
