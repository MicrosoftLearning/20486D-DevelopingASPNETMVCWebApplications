using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Services;

namespace ViewComponentsExample.Controllers
{
    public class HomeController : Controller
    {
        IPersonProvider _personProvider;

        public HomeController(IPersonProvider personProvider)
        {
            _personProvider = personProvider;
        }

        public IActionResult Index()
        {
            ViewBag.Rows = 5;
            ViewBag.Columns = 3;
            ViewBag.People = _personProvider.PersonList;
            return View();
        }
    }
}