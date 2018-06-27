using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutExample.Data;
using Microsoft.AspNetCore.Mvc;

namespace LayoutExample.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students
                .SingleOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}