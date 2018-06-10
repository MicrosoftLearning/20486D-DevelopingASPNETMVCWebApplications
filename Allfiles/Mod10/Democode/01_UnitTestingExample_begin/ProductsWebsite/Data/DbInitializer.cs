using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsWebsite.Models;

namespace ProductsWebsite.Data
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
                new Product { Name = "Basketball", BasePrice= 5.5F, Description = "A spherical ball used in basketball games.", ImageName = "basket-ball" },
                new Product { Name = "Blue Cupcake", BasePrice = 2.5F, Description = "Cupcake topped with Blue mysterious and delicous cream.", ImageName = "blue-cupcake" },
                new Product { Name = "Chocolate Cupcake", BasePrice = 4F, Description = "Chocolate cupcakes topped with chocolate frosting.", ImageName = "chocolate-cupcake" },
                new Product { Name = "Traffic Cone", BasePrice = 3F, Description = "An orange cone that is used to be placed on roads or footpaths to temporarily redirect traffic in a safe manner.", ImageName = "traffic-cone" },
                new Product { Name = "Football", BasePrice = 2F, Description = "A ball inflated with air that is being played by using your feet.", ImageName = "foot-ball" }
            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }

            context.SaveChanges();
        }
    }
}
