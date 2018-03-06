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
        public CakeStoreApiController(IData data)
        {
            _data = data;
        }

        [HttpGet("/api/CakeStore")]
        public IEnumerable<CakeStore> GetAll()
        {
            return _data.CakesInitializeData();
        }

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