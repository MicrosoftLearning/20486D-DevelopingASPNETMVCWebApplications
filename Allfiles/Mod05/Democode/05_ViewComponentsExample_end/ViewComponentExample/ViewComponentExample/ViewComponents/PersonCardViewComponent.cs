using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewExample.ViewComponents
{
    public class PersonCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            return View("CardDesign", id);
        }
    }
}
