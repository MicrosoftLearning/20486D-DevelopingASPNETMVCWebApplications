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
        private HttpClient _client;

        public HomeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:64231/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> GetByIdAsync()
        {
            GroceryStore grocery = null;
            HttpResponseMessage response = await _client.GetAsync("api/store/1");
            if (response.IsSuccessStatusCode)
            {
                grocery = await response.Content.ReadAsAsync<GroceryStore>();
            }
            return new ObjectResult(grocery);
        }

        public async Task<IActionResult> PostAsync()
        {
            GroceryStore newGrocery = new GroceryStore { Id = 3, Name = "Martin General Stores", Address = "4160  Oakwood Avenue" };
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/store", newGrocery);
            response.EnsureSuccessStatusCode();
            return new ObjectResult(newGrocery);
        }
    }
}