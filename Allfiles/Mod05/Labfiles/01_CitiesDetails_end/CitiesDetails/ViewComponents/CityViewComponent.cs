using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CitiesDetails.ViewComponents
{
    public class CityViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string cityName)
        {
            ViewBag.CurrentCityName = cityName;
            return View("SelectCity");
        }
    }
}
