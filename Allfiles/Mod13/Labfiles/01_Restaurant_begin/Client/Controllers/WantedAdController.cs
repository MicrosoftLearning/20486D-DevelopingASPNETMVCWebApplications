using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Client.Models;

namespace Client.Controllers
{
    public class WantedAdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}