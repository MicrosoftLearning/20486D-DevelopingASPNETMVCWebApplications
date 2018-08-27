using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using Server.Models;

namespace Client.Controllers
{
    public class ReservationController : Controller
    {
        private IHttpClientFactory _httpClient;
        private IEnumerable<RestaurantBranch> _restaurantBranches;

        public ReservationController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateRestaurantBranchesDropDownListAsync();
            return View();
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreatePostAsync(OrderTable orderTable)
        {
            var client = _httpClient.CreateClient();
            var response = await client.PostAsJsonAsync("http://localhost:54517/api/Reservation", orderTable);
            response.EnsureSuccessStatusCode();
            return RedirectToAction(nameof(ThankYou));
        }

        private async Task PopulateRestaurantBranchesDropDownListAsync(int? selectedBranch = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:54517/api/RestaurantBranches");
            request.Headers.Add("Accept", "application/json");
            var client = _httpClient.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                _restaurantBranches = await response.Content.ReadAsAsync<IEnumerable<RestaurantBranch>>();
            }
            ViewBag.RestaurantBranchId = new SelectList(_restaurantBranches, "Id", "City", selectedBranch);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}