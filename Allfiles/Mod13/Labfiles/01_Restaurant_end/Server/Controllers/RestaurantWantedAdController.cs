using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantWantedAdController : ControllerBase
    {
        private RestaurantContext _context;

        public RestaurantWantedAdController(RestaurantContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<EmployeeRequirements>> Get()
        {
            var requirements = from r in _context.EmployeesRequirements
                           orderby r.JobTitle
                           select r;
            return requirements.ToList();
        }
    }
}