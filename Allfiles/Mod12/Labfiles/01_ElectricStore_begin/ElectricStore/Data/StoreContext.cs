using ElectricStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricStore.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MenuCategory> menuCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CustomersProducts>()
         .HasKey(c => new { c.ProductId, c.CustomerId });

            modelBuilder.Entity<CustomersProducts>()
                .HasOne(c => c.Customer)
                .WithMany(p => p.CustomerProducts)
                .HasForeignKey(cp => cp.CustomerId);

            modelBuilder.Entity<CustomersProducts>()
                .HasOne(p => p.Product)
                .WithMany(c => c.CustomerProducts)
                .HasForeignKey(cp => cp.ProductId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.MenuCategory)
                .WithMany(c => c.Products);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "TV",
                    Description = "Smart TV 49 Inch",
                    Price = 850,
                    ImageMimeType = "image/jpeg",
                    PhotoFileName = "tv.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Coffee Machine",
                    Description = "Coffee maker",
                    Price = 200,
                    ImageMimeType = "image/jpeg",
                    PhotoFileName = "coffee-machine.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Fax Machine",
                    Description = "Multifunction a printer and a fax machine",
                    Price = 390,
                    ImageMimeType = "image/jpeg",
                    PhotoFileName = "fax-machine.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 4,
                    ProductName = "Washer",
                    Description = "Automatic washing laundry machine",
                    Price = 1499,
                    ImageMimeType = "image/jpeg",
                    PhotoFileName = "washer.jpg",
                    CategoryId = 1
                });

            modelBuilder.Entity<MenuCategory>().HasData(
                new MenuCategory
                {
                    Id = 1,
                    Name = "Home Electrical Equipment"
                },
                new MenuCategory
                {
                    Id = 2,
                    Name = "Office Electrical Equipment"
                });
        }
    }
}
