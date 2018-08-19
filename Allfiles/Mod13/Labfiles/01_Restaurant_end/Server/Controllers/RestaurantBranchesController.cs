using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantBranchesController : ControllerBase
    {
        private RestaurantContext _context;

        public RestaurantBranchesController(RestaurantContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[Produces("application/xml")]
        public ActionResult<List<RestaurantBranch>> Get()
        {
            return _context.RestaurantBranches.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantBranch> GetById(int id)
        {
            var restaurant = _context.RestaurantBranches.FirstOrDefault(p => p.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }
    }
}