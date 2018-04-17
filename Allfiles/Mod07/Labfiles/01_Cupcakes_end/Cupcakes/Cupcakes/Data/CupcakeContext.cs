using Cupcakes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cupcakes.Data
{
    public class CupcakeContext : DbContext
    {
        public CupcakeContext(DbContextOptions<CupcakeContext> options) :base(options)
        {
        }

        public DbSet<Cupcake> Cupcakes { get; set; }
        public DbSet<Bakery> Bakeries { get; set; }
    }
}
