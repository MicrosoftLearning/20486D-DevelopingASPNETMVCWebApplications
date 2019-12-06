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
                   Street = "610  St Marys Street",
                   City = "Winnipeg",
                   Open = true,
                   PhoneNumber = "(20)-4266-8812"
               },
               new RestaurantBranch
               {
                   Id = 2,
                   Street = "Jedburgh 106 Road",
                   City = "Lesnewth",
                   Open = true,
                   PhoneNumber = "(07)-0116-7991"
               },
               new RestaurantBranch
               {
                   Id = 3,
                   Street = "Ruschestrasse 99 Road",
                   City = "Schönebeck",
                   Open = false,
                   PhoneNumber = "(03)-4584-9768"
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
                   JobTitle = "Dishwasher",
                   JobDescription = "Clean dishes, kitchen, and food preparation equipment.",
                   MinimumAge = 16.5,
                   PricePerHour = 15
               },
               new EmployeeRequirements
               {
                   Id = 2,
                   JobTitle = "Waiter",
                   JobDescription = "Take orders and serve food to Guests in our restaurant.",
                   MinimumAge = 18,
                   PricePerHour = 22
               },
               new EmployeeRequirements
               {
                   Id = 3,
                   JobTitle = "Manager",
                   JobDescription = "Responsible for the efficient running and profitability of the restaurants.",
                   MinimumAge = 22,
                   PricePerHour = 50
               },
               new EmployeeRequirements
               {
                   Id = 4,
                   JobTitle = "Bartender",
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
