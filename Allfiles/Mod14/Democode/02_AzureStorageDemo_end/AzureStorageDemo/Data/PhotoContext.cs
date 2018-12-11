using AzureStorageDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureStorageDemo.Data
{
    public class PhotoContext : DbContext
    {
        public PhotoContext(DbContextOptions<PhotoContext> options)
          : base(options)
        {

        }

        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>().HasData(
                new Photo
                {
                    Id = 1,
                    Title = "Flower",
                    Description = "Cow parsley, photographed in close up.",
                    ImageName = "flower.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo
                {
                    Id = 2,
                    Title = "Orchard",
                    Description = "This was taken on a sunny fall day.",
                    ImageName = "orchard.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo
                {
                    Id = 3,
                    Title = "Blackberries",
                    Description = "This was late for blackberries so they are a little past their best.",
                    ImageName = "blackberries.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo
                {
                    Id = 4,
                    Title = "Ripples",
                    Description = "Interesting reflections and colors in this marine shot.",
                    ImageName = "ripples.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo
                {
                    Id = 5,
                    Title = "View Along a Path",
                    Description = "The light was great through the trees so I had to stop and take this.",
                    ImageName = "path.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo
                {
                    Id = 6,
                    Title = "Headland View",
                    Description = "A beautiful view on a beautiful day.",
                    ImageName = "headland.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo
                {
                    Id = 7,
                    Title = "Fungi",
                    Description = "Found a fugi During a walk in the forest.",
                    ImageName = "fungi.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                });
        }
    }
}
