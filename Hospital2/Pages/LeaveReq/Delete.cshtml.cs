using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hospital2.Models;

namespace Hospital2.Pages.LeaveReq
{
    public class DeleteModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public DeleteModel(Hospital2.Models.Hospital2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public LeaveRequests LeaveRequests { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LeaveRequests == null)
            {
                return NotFound();
            }

            var leaverequests = await _context.LeaveRequests.FirstOrDefaultAsync(m => m.Id == id);

            if (leaverequests == null)
            {
                return NotFound();
            }
            else 
            {
                LeaveRequests = leaverequests;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.LeaveRequests == null)
            {
                return NotFound();
            }
            var leaverequests = await _context.LeaveRequests.FindAsync(id);

            if (leaverequests != null)
            {
                LeaveRequests = leaverequests;
                _context.LeaveRequests.Remove(LeaveRequests);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
