using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShirtStoreWebsite.Models;

namespace ShirtStoreWebsite.Data
{
    public class ShirtContext : DbContext
    {
        public ShirtContext(DbContextOptions<ShirtContext> options) : base(options)
        {
        }

        public DbSet<Shirt> Shirts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shirt>().HasData(
                new Shirt { Id = 1, Color = ShirtColor.Black, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 2, Color = ShirtColor.Black, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 3, Color = ShirtColor.Black, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 4, Color = ShirtColor.Black, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 5, Color = ShirtColor.Black, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 6, Color = ShirtColor.Black, Size = ShirtSize.XXL, Price = 24.5F },
                new Shirt { Id = 7, Color = ShirtColor.Red, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 8, Color = ShirtColor.Red, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 9, Color = ShirtColor.Red, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 10, Color = ShirtColor.Red, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 11, Color = ShirtColor.Red, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 12, Color = ShirtColor.Red, Size = ShirtSize.XXL, Price = 24.5F },
                new Shirt { Id = 13, Color = ShirtColor.Gray, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 14, Color = ShirtColor.Gray, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 15, Color = ShirtColor.Gray, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 16, Color = ShirtColor.Gray, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 17, Color = ShirtColor.Gray, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 18, Color = ShirtColor.Gray, Size = ShirtSize.XXL, Price = 24.5F },
                new Shirt { Id = 19, Color = ShirtColor.White, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 20, Color = ShirtColor.White, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 21, Color = ShirtColor.White, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 22, Color = ShirtColor.White, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 23, Color = ShirtColor.White, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 24, Color = ShirtColor.White, Size = ShirtSize.XXL, Price = 24.5F },
                new Shirt { Id = 25, Color = ShirtColor.Blue, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 26, Color = ShirtColor.Blue, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 27, Color = ShirtColor.Blue, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 28, Color = ShirtColor.Blue, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 29, Color = ShirtColor.Blue, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 30, Color = ShirtColor.Blue, Size = ShirtSize.XXL, Price = 24.5F },
                new Shirt { Id = 31, Color = ShirtColor.Yellow, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 32, Color = ShirtColor.Yellow, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 33, Color = ShirtColor.Yellow, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 34, Color = ShirtColor.Yellow, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 35, Color = ShirtColor.Yellow, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 36, Color = ShirtColor.Yellow, Size = ShirtSize.XXL, Price = 24.5F },
                new Shirt { Id = 37, Color = ShirtColor.Green, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 38, Color = ShirtColor.Green, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 39, Color = ShirtColor.Green, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 40, Color = ShirtColor.Green, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 41, Color = ShirtColor.Green, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 42, Color = ShirtColor.Green, Size = ShirtSize.XXL, Price = 24.5F }
            );
        }
    }
}
