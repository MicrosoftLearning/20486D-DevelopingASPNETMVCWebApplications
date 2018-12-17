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
                new Shirt { Id = 1, Tax = 1.2F, Color = ShirtColor.Black, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 2, Tax = 1.2F, Color = ShirtColor.Black, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 3, Tax = 1.2F, Color = ShirtColor.Black, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 4, Tax = 1.2F, Color = ShirtColor.Black, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 5, Tax = 1.2F, Color = ShirtColor.Black, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 6, Tax = 1.2F, Color = ShirtColor.Black, Size = ShirtSize.XXL, Price = 24.5F },
                new Shirt { Id = 7, Tax = 1.2F, Color = ShirtColor.Red, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 8, Tax = 1.2F, Color = ShirtColor.Red, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 9, Tax = 1.2F, Color = ShirtColor.Red, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 10, Tax = 1.2F, Color = ShirtColor.Red, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 11, Tax = 1.2F, Color = ShirtColor.Red, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 12, Tax = 1.2F, Color = ShirtColor.Red, Size = ShirtSize.XXL, Price = 24.5F },
                new Shirt { Id = 13, Tax = 1.2F, Color = ShirtColor.Gray, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 14, Tax = 1.2F, Color = ShirtColor.Gray, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 15, Tax = 1.2F, Color = ShirtColor.Gray, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 16, Tax = 1.2F, Color = ShirtColor.Gray, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 17, Tax = 1.2F, Color = ShirtColor.Gray, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 18, Tax = 1.2F, Color = ShirtColor.Gray, Size = ShirtSize.XXL, Price = 24.5F },
                new Shirt { Id = 19, Tax = 1.2F, Color = ShirtColor.White, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 20, Tax = 1.2F, Color = ShirtColor.White, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 21, Tax = 1.2F, Color = ShirtColor.White, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 22, Tax = 1.2F, Color = ShirtColor.White, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 23, Tax = 1.2F, Color = ShirtColor.White, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 24, Tax = 1.2F, Color = ShirtColor.White, Size = ShirtSize.XXL, Price = 24.5F },
                new Shirt { Id = 25, Tax = 1.2F, Color = ShirtColor.Blue, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 26, Tax = 1.2F, Color = ShirtColor.Blue, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 27, Tax = 1.2F, Color = ShirtColor.Blue, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 28, Tax = 1.2F, Color = ShirtColor.Blue, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 29, Tax = 1.2F, Color = ShirtColor.Blue, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 30, Tax = 1.2F, Color = ShirtColor.Blue, Size = ShirtSize.XXL, Price = 24.5F },
                new Shirt { Id = 31, Tax = 1.2F, Color = ShirtColor.Yellow, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 32, Tax = 1.2F, Color = ShirtColor.Yellow, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 33, Tax = 1.2F, Color = ShirtColor.Yellow, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 34, Tax = 1.2F, Color = ShirtColor.Yellow, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 35, Tax = 1.2F, Color = ShirtColor.Yellow, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 36, Tax = 1.2F, Color = ShirtColor.Yellow, Size = ShirtSize.XXL, Price = 24.5F },
                new Shirt { Id = 37, Tax = 1.2F, Color = ShirtColor.Green, Size = ShirtSize.XS, Price = 15F },
                new Shirt { Id = 38, Tax = 1.2F, Color = ShirtColor.Green, Size = ShirtSize.S, Price = 17F },
                new Shirt { Id = 39, Tax = 1.2F, Color = ShirtColor.Green, Size = ShirtSize.M, Price = 19.5F },
                new Shirt { Id = 40, Tax = 1.2F, Color = ShirtColor.Green, Size = ShirtSize.L, Price = 21F },
                new Shirt { Id = 41, Tax = 1.2F, Color = ShirtColor.Green, Size = ShirtSize.XL, Price = 23F },
                new Shirt { Id = 42, Tax = 1.2F, Color = ShirtColor.Green, Size = ShirtSize.XXL, Price = 24.5F }
            );
        }
    }
}
