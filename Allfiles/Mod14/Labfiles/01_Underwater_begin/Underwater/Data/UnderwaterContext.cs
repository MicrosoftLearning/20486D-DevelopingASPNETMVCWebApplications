using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Underwater.Models;

namespace Underwater.Data
{
    public class UnderwaterContext : DbContext
    {
        public UnderwaterContext(DbContextOptions<UnderwaterContext> options) : base(options)
        {
        }

        public DbSet<Aquarium> Aquariums { get; set; }
        public DbSet<Fish> fishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aquarium>().HasData(
               new Aquarium
               {
                   AquariumId = 1,
                   Name = "Fish Aquarium",
                   Address = "4121  Broadway Street",
                   Number = 818 - 392 - 0763,
                   Open = true,
               },
               new Aquarium
               {
                   AquariumId = 2,
                   Name = "Ocean Aquarium",
                   Address = "3219  Central Avenue",
                   Number = 310 - 643 - 0965,
                   Open = false,
               },
               new Aquarium
               {
                   AquariumId = 3,
                   Name = "Best Aquarium",
                   Address = "128  Stewart Street",
                   Number = 336 - 209 - 6822,
                   Open = true,
               }
               );

            modelBuilder.Entity<Fish>().HasData(
               new Fish
               {
                   FishId = 1,
                   Name = "Goldfish",
                   ScientificName = "Carassius auratus",
                   ImageMimeType = "image/jpeg",
                   ImageName = "goldfish.jpg",
                   AquariumId = 1
               },
               new Fish
               {
                   FishId = 2,
                   Name = "Starfish",
                   ScientificName = "Asteroidea",
                   ImageMimeType = "image/jpeg",
                   ImageName = "starfish.jpg",
                   AquariumId = 1
               },
               new Fish
               {
                   FishId = 3,
                   Name = "Clownfish",
                   ScientificName = "Amphiprion ocellaris",
                   ImageMimeType = "image/jpeg",
                   ImageName = "clownfish.jpg",
                   AquariumId = 1
               }
               );
        }
    }
}
