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
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IceCreamFlavorsCustomers>()
           .HasKey(c => new { c.IceCreamId, c.CustomerId });

            modelBuilder.Entity<IceCreamFlavorsCustomers>()
                .HasOne(ic => ic.IceCream)
                .WithMany(i => i.IceCreamFlavors)
                .HasForeignKey(ic => ic.IceCreamId);

            modelBuilder.Entity<IceCreamFlavorsCustomers>()
               .HasOne(ic => ic.Customer)
               .WithMany(c => c.IceCreamFlavors)
               .HasForeignKey(ic => ic.CustomerId);

            modelBuilder.Entity<IceCream>().HasData(
               new IceCream
               {
                   IceCreamId = 1,
                   Price = 8,
                   Flavor = IceCreamFlavor.VanillaIceCream1,/*with Caramel Ripple and Almonds*/
                   ImageMimeType = "image/jpeg",
                   PhotoFileName = "icecream-1.jpg"
               },
                new IceCream
                {
                    IceCreamId = 2,
                    Price = 4,
                    Flavor = IceCreamFlavor.VanillaIceCream2,/*with Cherry Dark Chocolate Ice Cream*/
                    ImageMimeType = "image/jpeg",
                    PhotoFileName = "icecream-2.jpg"
                },
                new IceCream
                {
                    IceCreamId = 3,
                    Price = 6,
                    Flavor = IceCreamFlavor.VanillaIceCream3,/*with Pistachio*/
                    ImageMimeType = "image/jpeg",
                    PhotoFileName = "icecream-3.jpg"
                });
        }
    }
}
