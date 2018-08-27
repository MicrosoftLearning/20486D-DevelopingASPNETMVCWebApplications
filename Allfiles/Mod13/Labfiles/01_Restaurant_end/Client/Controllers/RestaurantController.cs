using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Server.Models;

namespace Client.Controllers
{
    public class RestaurantController : Controller
    {
        private IHttpClientFactory _httpClient;
        private IEnumerable<RestaurantBranch> _restaurantBranches;

        public RestaurantController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:54517/api/RestaurantBranches");
            request.Headers.Add("Accept", "application/json");
            var client = _httpClient.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                _restaurantBranches = await response.Content.ReadAsAsync<IEnumerable<RestaurantBranch>>();
            }
            return View(_restaurantBranches);
        }
    }
}