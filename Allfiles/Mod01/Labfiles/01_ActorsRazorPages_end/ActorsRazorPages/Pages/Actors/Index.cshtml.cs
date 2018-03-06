using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActorsRazorPages.Models;

namespace ActorsRazorPages.Pages.Actors
{
    public class IndexModel : PageModel
    {
        private IData _data;

        public IndexModel(IData data)
        {
            _data = data;
        }

        public List<Actor> Actors { get; set; }

        public void OnGet()
        {
            Actors = _data.ActorsInitializeData();
        }
    }
}