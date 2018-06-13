using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShirtStoreWebsite.Models;

namespace ShirtStoreWebsite.Controllers
{
    public class ShirtController : Controller
    {
        List<Shirt> shirts = new List<Shirt>()
            {
                new Shirt{ Id =1, Color = ShirtColor.Black, Size = ShirtSize.M, Price=2.2F },
                new Shirt{ Id =2, Color = ShirtColor.Red, Size = ShirtSize.M, Price=2.2F },
                new Shirt{ Id =3, Color = ShirtColor.Blue, Size = ShirtSize.L, Price=2.2F }
            };
        public IActionResult Index()
        {
            return View(shirts);
        }

        public IActionResult AddShirt(Shirt shirt)
        {
            shirts.Add(shirt);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            shirts.Remove(shirts.Where(s => s.Id == id).First());
            return RedirectToAction("Index");
        }
    }
}