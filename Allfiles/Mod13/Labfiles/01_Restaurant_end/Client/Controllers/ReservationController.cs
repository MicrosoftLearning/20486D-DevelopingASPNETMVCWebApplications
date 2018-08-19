using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Client.Controllers
{
    public class ReservationController : Controller
    {
        private IHttpClientFactory _httpClient;

        public ReservationController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreatePostAsync(OrderTable orderTable)
        {
            var client = _httpClient.CreateClient();
            var response = await client.PostAsJsonAsync("http://localhost:54517/api/Reservation", orderTable);
            response.EnsureSuccessStatusCode();
            return View(orderTable);
        }
    }
}