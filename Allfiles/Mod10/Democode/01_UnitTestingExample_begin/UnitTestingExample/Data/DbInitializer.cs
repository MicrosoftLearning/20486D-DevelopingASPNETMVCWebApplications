using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestingExample.Models;

namespace UnitTestingExample.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();
            if (context.Products.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new Product { Name = "Milk", BasePrice= 5.5F, Description = "Fresh cold Milk"},
                new Product { Name = "Salt", BasePrice = 2.5F, Description = "White and full of Sodium"},
                new Product { Name = "Butter", BasePrice = 4F, Description = "Delicate french butter"},
                new Product { Name = "Tomato", BasePrice = 3F, Description = "Red and Round"},
                new Product { Name = "Sugar", BasePrice = 2F, Description = "It's Sweet"}
            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }

            context.SaveChanges();
        }
    }
}
