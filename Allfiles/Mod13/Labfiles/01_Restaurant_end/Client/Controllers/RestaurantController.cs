using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Client.Controllers
{
    public class RestaurantController : Controller
    {
        private IHttpClientFactory _httpClient;
        private RestaurantBranch _RestaurantBranch;
        private IEnumerable<RestaurantBranch> _restaurantBranches;

        public RestaurantController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:64231/api/RestaurantBranches");
            request.Headers.Add("Accept", "application/json");

            var client = _httpClient.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                _restaurantBranches = await response.Content.ReadAsAsync<IEnumerable<RestaurantBranch>>();
            }
            return View(_restaurantBranches);
        }

        [HttpGet("/Details")]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:64231/api/RestaurantBranches/" + id);
            request.Headers.Add("Accept", "application/json");
            var client = _httpClient.CreateClient();

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                _RestaurantBranch = await response.Content.ReadAsAsync<RestaurantBranch>();
            }
            return View(_RestaurantBranch);
        }

        [HttpGet("/Restaurant")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/Restaurant")]
        public async Task<IActionResult> CreatePostAsync(RestaurantBranch restaurant)
        {
            var client = _httpClient.CreateClient();
            var response = await client.PostAsJsonAsync("http://localhost:64231/api/RestaurantBranches", restaurant);
            response.EnsureSuccessStatusCode();
            return View(restaurant);
        }
    }
}