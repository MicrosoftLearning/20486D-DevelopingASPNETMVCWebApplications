using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private LibraryContext _context;
        private IHostingEnvironment _environment;

        public LibraryController(LibraryContext libraryContext, IHostingEnvironment environment)
        {
            _context = libraryContext;
            _environment = environment;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult GetBooks()
        {
            var booksQuery = from b in _context.Books
                             orderby b.Author
                             select b;

            return View(booksQuery);
        }

        [Authorize]
        public IActionResult GetBooksByGener()
        {
            var booksGenerQuery = from b in _context.Books
                                  orderby b.Genre.Name
                                  select b;

            return View(booksGenerQuery);
        }

        [Authorize]
        public IActionResult LendingBook(int id)
        {
            Book book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            PopulateBooksDropDownList(book.Genre.Id);
            return View(book);
        }

        [Authorize]
        [HttpPost, ActionName("LendingBooks")]
        public async Task<IActionResult> LendingBookPost(int id)
        {
            var bookToUpdate = _context.Books.FirstOrDefault(b => b.Id == id);
            bool isUpdated = await TryUpdateModelAsync<Book>(
                                bookToUpdate,
                                "",
                                c => c.Available == false);
            if (isUpdated)
            {
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            PopulateBooksDropDownList(bookToUpdate.Genre.Id);
            return View(bookToUpdate);
        }

        private void PopulateBooksDropDownList(int? selectedBook = null)
        {
            var books = from b in _context.Books
                        orderby b.Author
                        select b;

            ViewBag.BookID = new SelectList(books.AsNoTracking(), "Id", "Name", selectedBook);
        }
    }
}