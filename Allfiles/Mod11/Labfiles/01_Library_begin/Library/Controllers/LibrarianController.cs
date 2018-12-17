using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibrarianController : Controller
    {
        private LibraryContext _context;

        public LibrarianController(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBook()
        {
            PopulateGenerDropDownList();
            return View();
        }

        [HttpPost, ActionName("AddBook")]
        public IActionResult AddBookPost(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.PhotoAvatar != null && book.PhotoAvatar.Length > 0)
                {
                    book.ImageMimeType = book.PhotoAvatar.ContentType;
                    book.ImageName = Path.GetFileName(book.PhotoAvatar.FileName);
                    using (var memoryStream = new MemoryStream())
                    {
                        book.PhotoAvatar.CopyTo(memoryStream);
                        book.PhotoFile = memoryStream.ToArray();
                    }
                    book.Available = true;
                    _context.Add(book);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(ThankYou));
            }
            PopulateGenerDropDownList(book.Genre.Id);
            return View();
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        private void PopulateGenerDropDownList(int? selectedGener = null)
        {
            var genres = from b in _context.Genres
                        orderby b.Name
                        select b;

            ViewBag.GenerList = new SelectList(genres.AsNoTracking(), "Id", "Name", selectedGener);
        }
    }
}