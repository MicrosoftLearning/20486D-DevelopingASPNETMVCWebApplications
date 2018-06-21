using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActorsRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ActorsRazorPages.Pages.Actors
{
    public class DetailsModel : PageModel
    {
        private IData _data;

        public Actor Actor { get; set; }

        public DetailsModel(IData data)
        {
            _data = data;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor = _data.GetActorById(id);

            if (Actor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}