using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XmlFormatExample.Models;

namespace XmlFormatExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private List<Animal> _animals = new List<Animal>();

        public AnimalsController()
        {
            _animals.Add(new Animal() { Id = 1, Name = "Lion", Family = "Mammal", Facts = "Lions are found especially in parts of Africa, and they are most active at night." });
            _animals.Add(new Animal() { Id = 2, Name = "Elephant", Family = "Mammal", Facts = "Elephants are intelligent animals and have a very good memories, they also display emotions signs." });
            _animals.Add(new Animal() { Id = 3, Name = "Shark", Family = "Fish", Facts = "Sharks live in the ocean, and average shark has 40-45 teeth" });
        }

        [HttpGet]
        [Produces("application/xml")]
        public ActionResult<List<Animal>> GetAll()
        {
            return _animals;
        }
    }
}

