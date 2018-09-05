using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooSite.Models;

namespace ZooSite.Data
{
    public class ZooContext : DbContext
    {
        public ZooContext(DbContextOptions<ZooContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>().HasData(
                 new Photo
                 {
                     PhotoID = 1,
                     Title = "Butterfly Garden",
                     Description = "The butterfly garden has more than 35 species of butterfly that can be seen by our visitors.",
                     PhotoFileName = "butterfly.jpg",
                     ImageMimeType = "image/jpeg"
                 },
                new Photo
                {
                    PhotoID = 2,
                    Title = "African Animals",
                    Description = "The African animals are the first sight that most people first notice upon entering the zoo, highly recommended.",
                    PhotoFileName = "lion.jpg",
                    ImageMimeType = "image/jpeg"
                },
                new Photo
                {
                    PhotoID = 3,
                    Title = "Underwater World",
                    Description = "Our aquarium tank contains aquatic animals.",
                    PhotoFileName = "octopus.jpg",
                    ImageMimeType = "image/jpeg"
                },
                new Photo
                {
                    PhotoID = 4,
                    Title = "Sea Birds",
                    Description = "The zoo sea birds department has a lot of special sea birds shows.",
                    PhotoFileName = "swan.jpg",
                    ImageMimeType = "image/jpeg"
                });
        }
    }
}
