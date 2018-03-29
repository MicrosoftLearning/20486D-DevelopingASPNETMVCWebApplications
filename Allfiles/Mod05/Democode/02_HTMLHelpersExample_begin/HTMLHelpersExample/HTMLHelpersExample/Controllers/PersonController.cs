using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HTMLHelpersExample.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Details(string personName)
        {

            return View();
        }

        public IActionResult GetImage(string personName)
        {
            return Content("");
        }
    }
}