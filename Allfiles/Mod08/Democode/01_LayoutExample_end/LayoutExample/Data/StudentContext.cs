using LayoutExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutExample.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                 new Student
                 {
                     StudentId = 1,
                     FirstName = "Tara",
                     LastName = "Brewer",
                     City = "Ocala",
                     Address = "317 Long Street",
                     Birthdate = new DateTime(1988, 06, 22),
                     Course = "Accounting & Finance",
                     StartedUniversityDate = new DateTime(2015, 10, 1)
                 },
                new Student
                {
                    StudentId = 2,
                    FirstName = "Andrew",
                    LastName = "Tippett",
                    City = "Anaheim",
                    Address = "3163 Nickel Road",
                    Birthdate = new DateTime(1992, 03, 5),
                    Course = "Architecture",
                    StartedUniversityDate = new DateTime(2017, 10, 1)
                },
                new Student
                {
                    StudentId = 3,
                    FirstName = "Isabella",
                    LastName = "Neild",
                    City = "Wellspring",
                    Address = "64 Shaw Drive",
                    Birthdate = new DateTime(1994, 02, 12),
                    Course = "Accounting & Finance",
                    StartedUniversityDate = new DateTime(2016, 10, 1)
                },
                new Student
                {
                    StudentId = 4,
                    FirstName = "Bryant",
                    LastName = "S. Willeford",
                    City = "MillerVille",
                    Address = "338 Hillview Drive",
                    Birthdate = new DateTime(1989, 01, 22),
                    Course = "Accounting & Finance",
                    StartedUniversityDate = new DateTime(2014, 10, 1)
                },
                new Student
                {
                    StudentId = 5,
                    FirstName = "Minerva",
                    LastName = "R. Lipe",
                    City = "Braedon",
                    Address = "3163 Nickel Road",
                    Birthdate = new DateTime(1990, 09, 15),
                    Course = "Architecture",
                    StartedUniversityDate = new DateTime(2017, 10, 1)
                });
        }
    }
}
