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
    public class ReservationController : ControllerBase
    {
        private RestaurantContext _context;

        public ReservationController(RestaurantContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<OrderTable> GetById(int id)
        {
            var order = _context.ReservationsTables.FirstOrDefault(p => p.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(OrderTable))]
        [ProducesResponseType(400)]
        public ActionResult<OrderTable> Create(OrderTable orderTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Add(orderTable);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = orderTable.Id }, orderTable);
        }
    }
}