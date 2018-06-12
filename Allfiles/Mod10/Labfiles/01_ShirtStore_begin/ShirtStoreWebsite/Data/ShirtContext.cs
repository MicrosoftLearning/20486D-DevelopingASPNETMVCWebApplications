using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ShirtStoreWebsite.Models;

namespace ShirtStoreWebsite.Data
{
    public class ShirtContext : DbContext
    {
        public ShirtContext(DbContextOptions<ShirtContext> options) : base(options)
        {
        }

        public DbSet<Shirt> Shirts{ get; set; }
    }
}
