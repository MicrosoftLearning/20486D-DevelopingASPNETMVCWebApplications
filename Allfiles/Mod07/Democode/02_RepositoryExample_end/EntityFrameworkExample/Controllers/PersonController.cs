using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkExample.Repositories;


namespace EntityFrameworkExample.Controllers
{
    public class PersonController : Controller
    {
        private IRepository _repository;

        public PersonController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var list = _repository.GetPeople();
            return View(list);
        }

        public IActionResult Create()
        {
            _repository.CreatePerson();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            _repository.UpdatePerson(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _repository.DeletePerson(id);
            return RedirectToAction(nameof(Index));
        }
    }
}