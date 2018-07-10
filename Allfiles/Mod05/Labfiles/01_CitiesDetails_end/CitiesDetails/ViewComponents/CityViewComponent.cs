using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CitiesDetails.Services;

namespace CitiesDetails.ViewComponents
{
    public class CityViewComponent : ViewComponent
    {
        ICityProvider _cities;

        public CityViewComponent(ICityProvider cities)
        {
            _cities = cities;
        }

        public async Task<IViewComponentResult> InvokeAsync(string cityName)
        {
            ViewBag.CurrentCityDetails = await GetCityDetails(cityName);
            return View("SelectCity");
        }

        private Task<CityDetails> GetCityDetails(string cityName)
        {
            return Task.FromResult<CityDetails>(_cities[cityName]);
        }
    }
}
