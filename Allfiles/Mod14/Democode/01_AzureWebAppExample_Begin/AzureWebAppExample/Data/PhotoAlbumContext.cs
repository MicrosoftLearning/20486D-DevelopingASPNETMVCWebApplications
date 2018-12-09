using AzureWebAppExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureWebAppExample.Data
{
    public class PhotoAlbumContext : DbContext
    {
        public PhotoAlbumContext(DbContextOptions<PhotoAlbumContext> options)
           : base(options)
        {

        }

        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>().HasData(
                new Photo
                {
                    PhotoID = 1,
                    Title = "Flower",
                    Description = "Cow parsley, photographed in close up.",
                    PhotoFileName = "flower.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo
                {
                    PhotoID = 2,
                    Title = "Orchard",
                    Description = "This was taken on a sunny fall day.",
                    PhotoFileName = "orchard.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo
                {
                    PhotoID = 3,
                    Title = "Blackberries",
                    Description = "This was late for blackberries so they are a little past their best.",
                    PhotoFileName = "blackberries.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo
                {
                    PhotoID = 4,
                    Title = "Ripples",
                    Description = "Interesting reflections and colors in this marine shot.",
                    PhotoFileName = "ripples.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo
                {
                    PhotoID = 5,
                    Title = "View Along a Path",
                    Description = "The light was great through the trees so I had to stop and take this.",
                    PhotoFileName = "path.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo
                {
                    PhotoID = 6,
                    Title = "Headland View",
                    Description = "A beautiful view on a beautiful day.",
                    PhotoFileName = "headland.jpg",
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                });
        }
    }
}
