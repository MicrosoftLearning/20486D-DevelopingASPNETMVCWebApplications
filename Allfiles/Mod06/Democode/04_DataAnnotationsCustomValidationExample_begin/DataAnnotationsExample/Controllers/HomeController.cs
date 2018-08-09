using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAnnotationsExample.Models;

namespace DataAnnotationsExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", student);
            }
            return View(student);
        }
    }
}