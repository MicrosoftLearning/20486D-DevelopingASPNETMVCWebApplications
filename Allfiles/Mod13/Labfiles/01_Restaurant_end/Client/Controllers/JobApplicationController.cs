using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Server.Models;

namespace Client.Controllers
{
    public class JobApplicationController : Controller
    {
        private IHttpClientFactory _httpClient;
        private IEnumerable<EmployeeRequirements> _employeeRequirements;

        public JobApplicationController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateEmployeeRequirementsDropDownListAsync();
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(JobApplication jobApplication)
        {
            return RedirectToAction(nameof(ThankYou));
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        private async Task PopulateEmployeeRequirementsDropDownListAsync(int? selectedRequirements = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:54517/api/RestaurantWantedAd");
            request.Headers.Add("Accept", "application/json");
            var client = _httpClient.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                _employeeRequirements = await response.Content.ReadAsAsync<IEnumerable<EmployeeRequirements>>();
            }

            ViewBag.EmployeeRequirementsId = new SelectList(_employeeRequirements, "Id", "JobTitle", selectedRequirements);
        }
    }
}