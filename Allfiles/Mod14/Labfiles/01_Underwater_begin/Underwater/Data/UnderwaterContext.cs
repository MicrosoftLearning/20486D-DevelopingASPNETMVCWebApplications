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
               }
               );

            modelBuilder.Entity<Fish>().HasData(
               new Fish
               {
               }
               );
        }
    }
}
