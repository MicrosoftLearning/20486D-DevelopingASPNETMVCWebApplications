using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HTMLHelpersExample.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.EmployeeNames = new string[] { "Michael", "Sarah", "Logan", "Elena", "Nathan" };
            return View();
        }

        public IActionResult Details(string employeeName)
        {
            ViewBag.SelectedEmployee = employeeName;
            return View();
        }

        public IActionResult GetImage(string employeeName)
        {
            return File($@"\images\{employeeName.ToLower()}.jpg", "image/jpeg");
        }
    }
}