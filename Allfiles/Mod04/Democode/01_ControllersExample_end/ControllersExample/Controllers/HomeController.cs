using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;


namespace ControllersExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ExampleModel model = new ExampleModel() { Sentence = "Welcome to module 4 demo 1" };
            return View(model);
        }

        public IActionResult ParamExample(string id)
        {
            return Content("My param is: " + id);
        }

        public IActionResult RouteDataExample()
        {
            string controller = (string)RouteData.Values["Controller"];
            string action = (string)RouteData.Values["action"];
            string id = (string)RouteData.Values["id"];
            return Content($"Action information: the action is in {controller} controller, the action name is {action} and the id value is {id}");
        }

        public IActionResult ViewBagExample()
        {
            ViewBag.Message = "ViewBag Example";
            return View();
        }

        public IActionResult ViewDataExample()
        {
            ViewData["Message"] = "ViewData Example";
            return View();
        }
    }
}