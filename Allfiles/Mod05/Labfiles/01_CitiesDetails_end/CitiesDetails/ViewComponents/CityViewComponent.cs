using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesDetails.ViewComponents
{
    public class CityViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string cityName)
        {
            return View("SelectCity", cityName);
        }
    }
}
