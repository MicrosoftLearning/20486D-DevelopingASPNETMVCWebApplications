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
            ViewBag.PersonNames = new string[] { "Michael", "Sarah", "Logan", "Elena", "Nathan" };
            return View();
        }

        public IActionResult Details(string personName)
        {
            ViewBag.SelectedPerson = personName;
            return View();
        }

        public IActionResult GetImage(string personName)
        {
            return File($@"\images\{personName.ToLower()}.jpg", "image/jpeg");
        }
    }
}