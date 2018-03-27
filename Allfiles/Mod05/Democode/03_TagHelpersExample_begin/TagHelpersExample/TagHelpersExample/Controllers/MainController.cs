using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TagHelpersExample.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Standard()
        {
            return View();
        }
        
        public IActionResult StandardWithParameter(string parameter1, string parameter2)
        {
            return View();
        }
    }
}