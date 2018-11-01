using IdentityExample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample.Data
{
    public class StudentContext : IdentityDbContext<Student>
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = 1,
                Name = "Accounting & Finance"
            },
            new Course
            {
                Id = 2,
                Name = "Archaeology & Anthropology"
            },
            new Course
            {
                Id = 3,
                Name = "Biology"
            },
            new Course
            {
                Id = 4,
                Name = "Chemistry"
            },
            new Course
            {
                Id = 5,
                Name = "Engineering Science"
            });
        }
    }
}
