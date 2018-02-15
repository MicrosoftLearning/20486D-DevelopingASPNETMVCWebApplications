using Microsoft.AspNetCore.Mvc;
using AnimlasMvc.Models;
using System.Collections.Generic;

namespace AnimlasMvc.Controllers
{
    public class AnimalsController : Controller
    {
        private static IData _tempData;

        //Ctor inject IData interface
        public AnimalsController(IData tempData)
        {
            _tempData = tempData;
        }
        // GET: Animals
        public IActionResult Index()
        {
            List<Animal> animals = _tempData.AnimalsInitializeData();
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Animals = animals;
            return View(indexViewModel);
        }

        // GET: Animals/Details/5
        public IActionResult Details(int? id)
        {
            var model = _tempData.GetAnimalById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }    
    }
}