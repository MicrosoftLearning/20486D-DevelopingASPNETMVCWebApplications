using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExample.Data;
using EntityFrameworkExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExample.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;
            Initialize();
        }

        private void Initialize()
        {
            _context.Database.EnsureCreated();
            if (!_context.People.Any())
            {
                _context.Add(new Person() { FirstName = "Tara", LastName = "Brewer", City = "Ocala", Address = "317 Long Street" });
                _context.Add(new Person() { FirstName = "Andrew", LastName = "Tippett", City = "Anaheim", Address = "3163 Nickel Road" });
                _context.SaveChanges();
            }
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
            _context.Add(new Person() { FirstName = "Robert ", LastName = "Berends", City = "Birmingham", Address = "2632 Petunia Way" });
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