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
        public DbSet<OrderTable> ReservationsTables { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantBranch>().HasData(
               new RestaurantBranch
               {
                   Id = 1,
                   Street = "610  St Marys Rd",
                   City = "Winnipeg",
                   Open = true,
                   PhoneNumber = "204-266-8812"
               },
               new RestaurantBranch
               {
                   Id = 2,
                   Street = "106  Jedburgh Road",
                   City = "Lesnewth",
                   Open = true,
                   PhoneNumber = "070-1136-7991"
               },
                new RestaurantBranch
                {
                    Id = 3,
                    Street = "Ruschestrasse 99",
                    City = "Schönebeck",
                    Open = false,
                    PhoneNumber = "03458-42-97-68"

                },
                 new RestaurantBranch
                 {
                     Id = 4,
                     Street = "20 Fitzroy Street",
                     City = "Greendale",
                     Open = true,
                     PhoneNumber = "(03)-8622-6758"

                 });

            modelBuilder.Entity<EmployeeRequirements>().HasData(
               new EmployeeRequirements
               {
                   Id = 1,
                   Job = JobTitle.Dishwasher,
                   JobDescription = "Clean dishes, kitchen, and food preparation equipment.",
                   MinimumAge = 16.5,
                   PricePerHour = 15
               },
               new EmployeeRequirements
               {
                   Id = 2,
                   Job = JobTitle.Waiter,
                   JobDescription = "Take orders and serve food to Guests in our restaurant.",
                   MinimumAge = 18,
                   PricePerHour = 22
               },
               new EmployeeRequirements
               {
                   Id = 3,
                   Job = JobTitle.Manager,
                   JobDescription = "Responsible for the efficient running and profitability of the restaurants.",
                   MinimumAge = 22,
                   PricePerHour = 50
               },
               new EmployeeRequirements
               {
                   Id = 4,
                   Job = JobTitle.Bartender,
                   JobDescription = "Interacting with customers, taking orders and serving drinks",
                   MinimumAge = 18,
                   PricePerHour = 45
               });

            modelBuilder.Entity<OrderTable>().HasData(
               new OrderTable
               {
                   Id = 1,
                   FirstName = "Francis",
                   LastName = "Fralick",
                   PhoneNumber = "636-412-2913",
                   ReservationTime = DateTime.Now,
                   DinnerGuests = 4,
                   RestaurantBranchId = 1
               });
        }
    }
}
