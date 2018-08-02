using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JQueryExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JQueryExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzashopController : ControllerBase
    {
        private List<Pizza> _pizzas = new List<Pizza>();

        public PizzashopController()
        {
            _pizzas.Add(new Pizza() {Id = 1, Toppings = "Mushrooms", Price =  10 });
            _pizzas.Add(new Pizza() { Id = 2, Toppings = "Extra cheese", Price = 8 });
            _pizzas.Add(new Pizza() { Id = 3, Toppings = "Black olives", Price = 9 });
            _pizzas.Add(new Pizza() { Id = 4, Toppings = "Pineapple", Price =  12});
        }

        [HttpGet("{id}")]
        public ActionResult<Pizza> GetById(int id)
        {
            Pizza pizza = _pizzas.SingleOrDefault(p => p.Id == id);
            if (pizza == null)
            {
                return NotFound();
            }
            return pizza;
        }

        [HttpPost]
        public ActionResult<Pizza> Post([FromBody] Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _pizzas.Add(pizza);
            return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);
        }
    }
}