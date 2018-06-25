using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActorsRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ActorsRazorPages.Pages.Actors
{
    public class IndexModel : PageModel
    {
        private IData _data;

        public IndexModel(IData data)
        {
            _data = data;
        }

        public IList<Actor> Actors { get; set; }

        public void OnGet()
        {
            Actors = _data.ActorsInitializeData();
        }
    }
}