using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShirtStoreWebsite.Models;
using ShirtStoreWebsite.Services;
using Microsoft.Extensions.Logging;

namespace ShirtStoreWebsite.Controllers
{
    public class ShirtController : Controller
    {
        private IShirtRepository _repository;
        private ILogger _logger;

        public ShirtController(IShirtRepository repository, ILogger<ShirtController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Shirt> shirts = _repository.GetShirts();
            return View(shirts);
        }

        public IActionResult AddShirt(Shirt shirt)
        {
            _repository.AddShirt(shirt);
            _logger.LogDebug($"A {shirt.Color.ToString()} shirt of size {shirt.Size.ToString()} with a price of {shirt.GetFormattedTaxedPrice()} was added successfully.");
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _repository.RemoveShirt(id);
                _logger.LogDebug($"A shirt with id {id} was removed successfully.");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while trying to delete shirt with id of {id}.");
                throw ex;
            }
        }
    }
}
