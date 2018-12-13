using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientSide.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ClientSide.Controllers
{
    public class HomeController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GetByIdAsync()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:61086");
            HttpResponseMessage response = httpClient.GetAsync("http://localhost:61106/api/store/1").Result;
            if (response.IsSuccessStatusCode)
            {
               GroceryStore grocery = await response.Content.ReadAsAsync<GroceryStore>();
                return new ObjectResult(grocery);
            }
            else
            {
                return Content("An error has occurred");
            }
        }

        public async Task<IActionResult> PostAsync()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:61086");
            GroceryStore newGrocery = new GroceryStore { Name = "Martin General Stores", Address = "4160  Oakwood Avenue" };
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("http://localhost:61106/api/store", newGrocery);
            if (response.IsSuccessStatusCode)
            {
                GroceryStore grocery = await response.Content.ReadAsAsync<GroceryStore>();
                return new ObjectResult(grocery);
            }
            else
            {
                return Content("An error has occurred");
            }
        }
    }
}