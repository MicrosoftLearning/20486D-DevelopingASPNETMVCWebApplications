using IceCreamCompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamCompany.Data
{
    public class IceCreamContext : DbContext
    {
        public IceCreamContext(DbContextOptions<IceCreamContext> options) : base(options)
        {
        }

        public DbSet<IceCream> IceCreamFlavors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IceCream>().HasData(
               new IceCream
               {
                   IceCreamId = 1,
                   Price = 8,
                   Flavor = "Vanilla ice cream",
                   ImageMimeType = "image/jpeg",
                   PhotoFileName = "icecream-1.jpg"
               },
                new IceCream
                {
                    IceCreamId = 2,
                    Price = 4,
                    Flavor = "Vanilla ice cream",
                    ImageMimeType = "image/jpeg",
                    PhotoFileName = "icecream-2.jpg"
                },
                new IceCream
                {
                    IceCreamId = 3,
                    Price = 6,
                    Flavor = "Vanilla ice cream",
                    ImageMimeType = "image/jpeg",
                    PhotoFileName = "icecream-3.jpg"
                });
        }
    }
}
