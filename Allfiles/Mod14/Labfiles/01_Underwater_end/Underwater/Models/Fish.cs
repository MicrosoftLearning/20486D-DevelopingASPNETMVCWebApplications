using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Underwater.Models
{
    public class Fish
    {
        [Key]
        public int FishId { get; set; }

        [Display(Name = "Fish Name:")]
        public string Name { get; set; }

        [Display(Name = "Scientific Name:")]
        public string ScientificName { get; set; }

        [Display(Name = "Common Name:")]
        public string CommonName { get; set; }

        [NotMapped]
        [Display(Name = "Picture:")]
        public IFormFile PhotoAvatar { get; set; }

        public string ImageName { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Please select an aquarium")]
        public int AquariumId { get; set; }

        public virtual Aquarium Aquarium { get; set; }
    }
}
