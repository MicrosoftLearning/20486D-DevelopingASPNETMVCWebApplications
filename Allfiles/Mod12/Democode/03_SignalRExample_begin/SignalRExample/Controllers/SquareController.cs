using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalRExample.Services;

namespace SignalRExample.Controllers
{
    public class SquareController : Controller
    {
        private ISquareManager _manager;

        public SquareController(ISquareManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.GetSquares());
        }
    }
}