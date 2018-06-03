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
                new Product { Name = "Basketball", BasePrice= 5.5F, Description = "A spherical ball used in basketball games." },
                new Product { Name = "Blue Cupcake", BasePrice = 2.5F, Description = "Cupcake topped with Blue mysterious and delicous cream." },
                new Product { Name = "Chocolate Cupcake", BasePrice = 4F, Description = "Chocolate cupcakes topped with chocolate frosting." },
                new Product { Name = "Traffic Cone", BasePrice = 3F, Description = "An orange cone that is used to be placed on roads or footpaths to temporarily redirect traffic in a safe manner." },
                new Product { Name = "Football", BasePrice = 2F, Description = "A ball inflated with air that is being played by using your feet." }
            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }

            context.SaveChanges();
        }
    }
}
