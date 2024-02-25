using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hospital2.Models;

namespace Hospital2.Pages.OncallReq
{
    public class DeleteModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public DeleteModel(Hospital2.Models.Hospital2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public OncallRequests OncallRequests { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OncallRequests == null)
            {
                return NotFound();
            }

            var oncallrequests = await _context.OncallRequests.FirstOrDefaultAsync(m => m.Id == id);

            if (oncallrequests == null)
            {
                return NotFound();
            }
            else 
            {
                OncallRequests = oncallrequests;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.OncallRequests == null)
            {
                return NotFound();
            }
            var oncallrequests = await _context.OncallRequests.FindAsync(id);

            if (oncallrequests != null)
            {
                OncallRequests = oncallrequests;
                _context.OncallRequests.Remove(OncallRequests);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
