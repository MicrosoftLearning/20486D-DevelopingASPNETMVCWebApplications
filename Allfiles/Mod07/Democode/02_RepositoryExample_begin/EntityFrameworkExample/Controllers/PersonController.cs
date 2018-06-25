using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkExample.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}