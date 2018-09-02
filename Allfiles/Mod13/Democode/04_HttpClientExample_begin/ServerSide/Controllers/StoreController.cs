using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerSide.Models;

namespace ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {

        private List<GroceryStore> _groceryStores = new List<GroceryStore>();

        public StoreController()
        {
            _groceryStores.Add(new GroceryStore() { Id = 1, Name = "Market Base", Address = "1882  State Street" });
            _groceryStores.Add(new GroceryStore() { Id = 2, Name = "Food Land", Address = "4122  Aaron Smith Drive" });
        }

        [HttpGet("{id}")]
        public ActionResult<GroceryStore> GetById(int id)
        {
            GroceryStore grocery = _groceryStores.SingleOrDefault(p => p.Id == id);
            if (grocery == null)
            {
                return NotFound();
            }
            return new ObjectResult(grocery);
        }

        [HttpPost]
        public ActionResult<GroceryStore> Create(GroceryStore groceryStore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _groceryStores.Add(groceryStore);
            return CreatedAtAction(nameof(GetById), new { id = groceryStore.Id }, groceryStore);
        }


    }
}