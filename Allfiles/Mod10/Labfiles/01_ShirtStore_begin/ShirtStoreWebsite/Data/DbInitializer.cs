using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShirtStoreWebsite.Models;

namespace ShirtStoreWebsite.Data
{
    public class DbInitializer
    {
        public static void Initialize(ShirtContext context)
        {
            context.Database.EnsureCreated();
            if (context.Shirts.Any())
            {
                return;
            }

            var shirts = new Shirt[]
            {
                new Shirt{ Color = ShirtColor.Black, Size = ShirtSize.XS, Price=15F },
                new Shirt{ Color = ShirtColor.Black, Size = ShirtSize.S, Price=17F },
                new Shirt{ Color = ShirtColor.Black, Size = ShirtSize.M, Price=19.5F },
                new Shirt{ Color = ShirtColor.Black, Size = ShirtSize.L, Price=21F },
                new Shirt{ Color = ShirtColor.Black, Size = ShirtSize.XL, Price=23F },
                new Shirt{ Color = ShirtColor.Black, Size = ShirtSize.XXL, Price=24.5F },
                new Shirt{ Color = ShirtColor.Red, Size = ShirtSize.XS, Price=15F },
                new Shirt{ Color = ShirtColor.Red, Size = ShirtSize.S, Price=17F },
                new Shirt{ Color = ShirtColor.Red, Size = ShirtSize.M, Price=19.5F },
                new Shirt{ Color = ShirtColor.Red, Size = ShirtSize.L, Price=21F },
                new Shirt{ Color = ShirtColor.Red, Size = ShirtSize.XL, Price=23F },
                new Shirt{ Color = ShirtColor.Red, Size = ShirtSize.XXL, Price=24.5F },
                new Shirt{ Color = ShirtColor.Gray, Size = ShirtSize.XS, Price=15F },
                new Shirt{ Color = ShirtColor.Gray, Size = ShirtSize.S, Price=17F },
                new Shirt{ Color = ShirtColor.Gray, Size = ShirtSize.M, Price=19.5F },
                new Shirt{ Color = ShirtColor.Gray, Size = ShirtSize.L, Price=21F },
                new Shirt{ Color = ShirtColor.Gray, Size = ShirtSize.XL, Price=23F },
                new Shirt{ Color = ShirtColor.Gray, Size = ShirtSize.XXL, Price=24.5F },
                new Shirt{ Color = ShirtColor.White, Size = ShirtSize.XS, Price=15F },
                new Shirt{ Color = ShirtColor.White, Size = ShirtSize.S, Price=17F },
                new Shirt{ Color = ShirtColor.White, Size = ShirtSize.M, Price=19.5F },
                new Shirt{ Color = ShirtColor.White, Size = ShirtSize.L, Price=21F },
                new Shirt{ Color = ShirtColor.White, Size = ShirtSize.XL, Price=23F },
                new Shirt{ Color = ShirtColor.White, Size = ShirtSize.XXL, Price=24.5F },
                new Shirt{ Color = ShirtColor.Blue, Size = ShirtSize.XS, Price=15F },
                new Shirt{ Color = ShirtColor.Blue, Size = ShirtSize.S, Price=17F },
                new Shirt{ Color = ShirtColor.Blue, Size = ShirtSize.M, Price=19.5F },
                new Shirt{ Color = ShirtColor.Blue, Size = ShirtSize.L, Price=21F },
                new Shirt{ Color = ShirtColor.Blue, Size = ShirtSize.XL, Price=23F },
                new Shirt{ Color = ShirtColor.Blue, Size = ShirtSize.XXL, Price=24.5F },
                new Shirt{ Color = ShirtColor.Yellow, Size = ShirtSize.XS, Price=15F },
                new Shirt{ Color = ShirtColor.Yellow, Size = ShirtSize.S, Price=17F },
                new Shirt{ Color = ShirtColor.Yellow, Size = ShirtSize.M, Price=19.5F },
                new Shirt{ Color = ShirtColor.Yellow, Size = ShirtSize.L, Price=21F },
                new Shirt{ Color = ShirtColor.Yellow, Size = ShirtSize.XL, Price=23F },
                new Shirt{ Color = ShirtColor.Yellow, Size = ShirtSize.XXL, Price=24.5F },
                new Shirt{ Color = ShirtColor.Green, Size = ShirtSize.XS, Price=15F },
                new Shirt{ Color = ShirtColor.Green, Size = ShirtSize.S, Price=17F },
                new Shirt{ Color = ShirtColor.Green, Size = ShirtSize.M, Price=19.5F },
                new Shirt{ Color = ShirtColor.Green, Size = ShirtSize.L, Price=21F },
                new Shirt{ Color = ShirtColor.Green, Size = ShirtSize.XL, Price=23F },
                new Shirt{ Color = ShirtColor.Green, Size = ShirtSize.XXL, Price=24.5F },
            };

            foreach (Shirt s in shirts)
            {
                context.Shirts.Add(s);
            }
            context.SaveChanges();
        }
    }
}
