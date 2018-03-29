using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAnnotationsExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataAnnotationsExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(Student person)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", person);
            }
            return View(person);
        }
    }
}