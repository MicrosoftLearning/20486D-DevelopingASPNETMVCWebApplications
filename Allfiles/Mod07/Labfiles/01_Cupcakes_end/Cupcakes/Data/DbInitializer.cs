using Cupcakes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cupcakes.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CupcakeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Bakeries.Any())
            {
                return;
            }

            var Bakeries = new Bakery[]
            {
                new Bakery{BakeryName = "Gluteus Free", Address = "635 Brighton Circle Road" , Quantity = 8},
                new Bakery{BakeryName = "Cupcakes Break", Address = "4323 Jerome Avenue" , Quantity = 22},
                new Bakery{BakeryName = "Cupcakes Ahead", Address = "2553 Pin Oak Drive" , Quantity = 18},
                new Bakery{BakeryName = "Sugar", Address = "1608 Charles Street" , Quantity = 30}
            };

            foreach (Bakery bakery in Bakeries)
            {
                context.Bakeries.Add(bakery);
            }
            context.SaveChanges();

            var cupcakes = new Cupcake[]
            {
                new Cupcake{CupcakeType = CupcakeType.Birthday, Description = "Vanilla cupcake with coconut cream", GlutenFree = true, Price = 2.5, BakeryId = 1, ImageMimeType = "image/jpeg", ImageName = "birthday-cupcake.jpg"},
                new Cupcake{CupcakeType = CupcakeType.Chocolate, Description = "Chocolate cupcake with caramel filling and chocolate butter cream", GlutenFree = false, Price = 3.2, BakeryId = 2, ImageMimeType = "image/jpeg", ImageName = "chocolate-cupcake.jpg"},
                new Cupcake{CupcakeType = CupcakeType.Strawberry, Description = "Chocolate cupcake with straberry cream filling", GlutenFree = false, Price = 4, BakeryId = 3, ImageMimeType = "image/jpeg", ImageName = "pink-cupcake.jpg"},
                new Cupcake{CupcakeType = CupcakeType.Turquoise, Description = "Vanilla cupcake with butter cream", GlutenFree = true, Price = 1.5, BakeryId = 4, ImageMimeType = "image/jpeg", ImageName = "turquoise-cupcake.jpg"}
            };

            foreach (Cupcake cupcake in cupcakes)
            {
                context.Cupcakes.Add(cupcake);
            }
            context.SaveChanges();

        }
    }
}
