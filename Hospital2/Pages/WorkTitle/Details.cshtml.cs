using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hospital2.Models;

namespace Hospital2.Pages.WorkTitle
{
    public class DetailsModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public DetailsModel(Hospital2.Models.Hospital2Context context)
        {
            _context = context;
        }

      public WorkTitles WorkTitles { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.WorkTitles == null)
            {
                return NotFound();
            }

            var worktitles = await _context.WorkTitles.FirstOrDefaultAsync(m => m.Id == id);
            if (worktitles == null)
            {
                return NotFound();
            }
            else 
            {
                WorkTitles = worktitles;
            }
            return Page();
        }
    }
}
