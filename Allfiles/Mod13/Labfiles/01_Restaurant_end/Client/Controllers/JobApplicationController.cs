using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Client.Models;

namespace Client.Controllers
{
    public class JobApplicationController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public JobApplicationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateEmployeeRequirementsDropDownListAsync();
            return View();
        }

        private async Task PopulateEmployeeRequirementsDropDownListAsync()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:54517");
            HttpResponseMessage response = await httpClient.GetAsync("api/RestaurantWantedAd");
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<EmployeeRequirements> employeeRequirements = await response.Content.ReadAsAsync<IEnumerable<EmployeeRequirements>>();
                ViewBag.EmployeeRequirements = new SelectList(employeeRequirements, "Id", "JobTitle");
            }
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}