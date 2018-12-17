using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsWebsite.Models;

namespace ProductsWebsite.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Basketball",
                    BasePrice = 5.5F,
                    Description = "A spherical ball used in basketball games.",
                    ImageName = "basketball"
                },
                new Product
                {
                    Id = 2,
                    Name = "Blue Cupcake",
                    BasePrice = 2.5F,
                    Description = "Cupcake topped with Blue mysterious and delicous cream.",
                    ImageName = "blue-cupcake"
                },
                new Product
                {
                    Id = 3,
                    Name = "Chocolate Cupcake",
                    BasePrice = 4F,
                    Description = "Chocolate cupcakes topped with chocolate frosting.",
                    ImageName = "chocolate-cupcake"
                },
                new Product
                {
                    Id = 4,
                    Name = "Traffic Cone",
                    BasePrice = 3F,
                    Description = "An orange cone that is used to be placed on roads or footpaths to temporarily redirect traffic in a safe manner.",
                    ImageName = "traffic-cone"
                },
                new Product
                {
                    Id = 5,
                    Name = "Football",
                    BasePrice = 2F,
                    Description = "A ball inflated with air that is being played by using your feet.",
                    ImageName = "football"
                });
        }
    }
}
