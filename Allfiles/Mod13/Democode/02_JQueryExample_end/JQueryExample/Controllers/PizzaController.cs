using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JQueryExample.Models;

namespace JQueryExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private List<Pizza> _pizzas = new List<Pizza>();

        public PizzaController()
        {
            _pizzas.Add(new Pizza() { Id = 1, Toppings = "mushrooms", Price = 10 });
            _pizzas.Add(new Pizza() { Id = 2, Toppings = "extra cheese", Price = 8 });
            _pizzas.Add(new Pizza() { Id = 3, Toppings = "black olives", Price = 9 });
            _pizzas.Add(new Pizza() { Id = 4, Toppings = "pineapple", Price = 12 });
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
        public ActionResult<Pizza> Post(Pizza pizza)
        {
            int pizzaMaxId = _pizzas.Max(i => i.Id);
            pizza.Id = ++pizzaMaxId;
            _pizzas.Add(pizza);
            return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);
        }
    }
}