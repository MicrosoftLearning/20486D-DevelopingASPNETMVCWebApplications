using Library.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{
    public class LibraryContext : IdentityDbContext<User>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
           : base(options)
        {
        }

        public DbSet<User> LibraryUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Mystery"
                },
                new Genre
                {
                    Id = 2,
                    Name = "History"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Science fiction"
                });

            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   Id = 1,
                   Name = "My mysterious adventures",
                   Author = "Ada J. Hawkins",
                   GenreId = 1,
                   Available = true,
                   ImageMimeType = "image/jpeg",
                   ImageName = "first-book.jpg",
                   Recommended = true,
                   DatePublished = new DateTime(2000, 6, 20).ToShortDateString()
               },
               new Book
               {
                   Id = 2,
                   Name = "My family history",
                   Author = "Janice O. Kaufman",
                   GenreId = 2,
                   Available = true,
                   ImageMimeType = "image/jpeg",
                   ImageName = "second-book.jpg",
                   Recommended = true,
                   DatePublished = new DateTime(2000, 6, 20).ToShortDateString()

               }, new Book
               {
                   Id = 3,
                   Name = "A wonderful story ",
                   Author = "Kristin A. McCoy",
                   GenreId = 3,
                   Available = true,
                   ImageMimeType = "image/jpeg",
                   ImageName = "third-book.jpg",
                   Recommended = true,
                   DatePublished = new DateTime(2000, 6, 20).ToShortDateString()
               });
        }
    }
}
