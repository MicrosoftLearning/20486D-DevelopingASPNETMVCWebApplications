using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CakeStoreApi.Models;

namespace CakeStoreApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CakeStoreApi")]
    public class CakeStoreApiController : Controller
    {
        private IData _data;

        //Ctor inject IData interface
        public CakeStoreApiController(IData data)
        {
            _data = data;
        }

        //Get all cakes list
        [HttpGet("/api/CakeStore")]
        public IEnumerable<CakeStore> GetAll()
        {
            return _data.CakesInitializeData();
        }

        //Get Cake by id
        [HttpGet("/api/CakeStore/{id}")]
        public IActionResult GetById(int? id)
        {
            var item = _data.GetCakeById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}