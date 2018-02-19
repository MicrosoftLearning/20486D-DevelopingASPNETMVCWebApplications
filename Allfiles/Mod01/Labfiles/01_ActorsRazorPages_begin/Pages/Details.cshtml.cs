using ActorsRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ActorsRazorPages.Pages.Actors
{
    public class DetailsModel : PageModel
    {


        private IData _data;

        public Actor Actor { get; set; }

        //Ctor inject IData interface
        public DetailsModel(IData data)
        {
            _data = data;
        }
        //Get Actor by the accepted id  
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