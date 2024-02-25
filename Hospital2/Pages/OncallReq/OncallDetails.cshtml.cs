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
    public class DetailsModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public DetailsModel(Hospital2.Models.Hospital2Context context)
        {
            _context = context;
        }

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
    }
}
