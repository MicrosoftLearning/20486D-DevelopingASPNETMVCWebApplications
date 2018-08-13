using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkExample.Data;
using EntityFrameworkExample.Models;


namespace EntityFrameworkExample.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.People.ToList());
        }

        public IActionResult Edit(int id)
        {
            var person = _context.People.SingleOrDefault(m => m.PersonId == id);
            person.FirstName = "Brandon";
            _context.Update(person);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            _context.Add(new Person() { FirstName = "Robert", LastName = "Berends", City = "Birmingham", Address = "2632 Petunia Way" });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var person = _context.People.SingleOrDefault(m => m.PersonId == id);
            _context.People.Remove(person);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}