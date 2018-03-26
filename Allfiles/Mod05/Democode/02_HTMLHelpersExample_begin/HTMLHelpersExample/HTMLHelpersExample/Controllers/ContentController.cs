using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HTMLHelpersExample.Controllers
{
    public class ContentController : Controller
    {
        public IActionResult ChangedPathAction()
        {
            return View();
        }
    }
}