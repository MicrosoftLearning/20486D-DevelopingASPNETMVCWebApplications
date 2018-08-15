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
            return _context.EmployeesRequirements.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeRequirements> GetById(int id)
        {
            var employee = _context.EmployeesRequirements.FirstOrDefault(p => p.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost]
        public ActionResult<RestaurantBranch> Post(EmployeeRequirements employeeRequirements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Add(employeeRequirements);
            return CreatedAtAction(nameof(GetById), new { id = employeeRequirements.Id }, employeeRequirements);
        }
    }
}