using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerSide.Models;
using System.Net.Http;
using System.Net.Http.Headers;


namespace ClientSide.Controllers
{
    public class HomeController : Controller
    {
        private IHttpClientFactory _httpClient;
        private GroceryStore grocery;

        public HomeController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> GetByIdAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:64231/api/store/1");
            request.Headers.Add("Accept", "application/json");
            var client = _httpClient.CreateClient();

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                grocery = await response.Content.ReadAsAsync<GroceryStore>();
            }
            return new ObjectResult(grocery);
        }

        public async Task<IActionResult> PostAsync()
        {
            var client = _httpClient.CreateClient();
            GroceryStore newGrocery = new GroceryStore { Id = 3, Name = "Martin General Stores", Address = "4160  Oakwood Avenue" };
            var response = await client.PostAsJsonAsync("http://localhost:64231/api/store", newGrocery);
            response.EnsureSuccessStatusCode();
            return new ObjectResult(newGrocery);
        }
    }
}