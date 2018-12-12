using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AzureStorageDemo.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [DisplayName("Picture")]
        public string ImageName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Upload")]
        [Required(ErrorMessage = "Please select a picture")]
        [NotMapped]
        public IFormFile PhotoAvatar { get; set; }

        public byte[] PhotoFile { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
    }
}
