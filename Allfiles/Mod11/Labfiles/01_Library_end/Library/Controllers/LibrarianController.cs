using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class LibrarianController : Controller
    {
        private LibraryContext _context;
        private UserManager<User> _userManage;
        private RoleManager<IdentityRole> _roleManager;

        public LibrarianController(LibraryContext libraryContext, UserManager<User> userManage, RoleManager<IdentityRole> roleManager)
        {
            _context = libraryContext;
            _userManage = userManage;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost, ActionName("AddBook")]
        [ValidateAntiForgeryToken]
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
                    book.Available = false;
                    _context.Add(book);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateBooksDropDownList(book.Genre.Id);
            return View();
        }

        private void PopulateBooksDropDownList(int? selectedGener = null)
        {
            var genres = from b in _context.Genres
                        orderby b.Name
                        select b;

            ViewBag.GenerList = new SelectList(genres.AsNoTracking(), "Id", "Name", selectedGener);
        }
    }
}