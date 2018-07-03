using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Models;

namespace Zoo.Data
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
                     Title = "Butterfly Garden",
                     Description = "In computing, a code segment, also known as a text segment or simply as text",
                     PhotoFileName = "butterfly.jpg",
                     ImageMimeType = "image/jpeg"
                 },
                new Photo
                {
                    Title = "African Animals",
                    Description = "In computing, a code segment, also known as a text segment or simply as text",
                    PhotoFileName = "lion.jpg",
                    ImageMimeType = "image/jpeg"
                },
                new Photo
                {
                    Title = "Underwater World",
                    Description = "In computing, a code segment, also known as a text segment or simply as text",
                    PhotoFileName = "octopus.jpg",
                    ImageMimeType = "image/jpeg"
                },
                new Photo
                {
                    Title = "Sea Birds",
                    Description = "In computing, a code segment, also known as a text segment or simply as text",
                    PhotoFileName = "swan.jpg",
                    ImageMimeType = "image/jpeg"
                });
        }
    }
}
