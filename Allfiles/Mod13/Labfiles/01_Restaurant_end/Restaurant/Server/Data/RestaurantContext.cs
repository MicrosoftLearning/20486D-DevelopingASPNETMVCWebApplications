using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantBranch> RestaurantBranches { get; set; }
        public DbSet<EmployeeRequirements> EmployeesRequirements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantBranch>().HasData(
               new RestaurantBranch
               {
                   
               });

            modelBuilder.Entity<EmployeeRequirements>().HasData(
               new EmployeeRequirements
               {

               });
        }
    }
}
