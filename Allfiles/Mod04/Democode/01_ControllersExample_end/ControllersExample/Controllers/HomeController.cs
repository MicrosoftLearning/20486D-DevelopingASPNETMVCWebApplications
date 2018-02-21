using ControllersExample.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
            return Content(string.Format("Action information: the action is in {0} controller, the action name is {1} and the id value is {2}",controller,action,id));
        }

        public IActionResult ViewBagExample()
        {
            ViewBag.Message = "View Bag Example";
            ViewBag.ServerTime = DateTime.Now;
            return View();
        }

        public IActionResult ViewDataExample()
        {
            ViewData["Message"] = "View Data Example";
            ViewData["ServerTime"] = DateTime.Now;
            return View();
        }
    }
}