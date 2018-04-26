using Microsoft.AspNetCore.Mvc;
using AnimalMvc.Models;
using System.Collections.Generic;

namespace AnimalMvc.Controllers
{
    public class AnimalsController : Controller
    {
        private static IData _tempData;
        public AnimalsController(IData tempData)
        {
            _tempData = tempData;
        }

        public IActionResult Index()
        {
            List<Animal> animals = _tempData.AnimalsInitializeData();
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Animals = animals;
            return View(indexViewModel);
        }

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