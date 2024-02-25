using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital2.Models;

namespace Hospital2.Pages.LeaveReq
{
    public class EditModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public EditModel(Hospital2.Models.Hospital2Context context)
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

            var leaverequests =  await _context.LeaveRequests.FirstOrDefaultAsync(m => m.Id == id);
            if (leaverequests == null)
            {
                return NotFound();
            }
            LeaveRequests = leaverequests;
           ViewData["LeaveStatusId"] = new SelectList(_context.LeaveStatus, "Id", "Id");
           ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id");
           ViewData["UserDetailId"] = new SelectList(_context.UserDetails, "Id", "AspNetUserId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LeaveRequests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveRequestsExists(LeaveRequests.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LeaveRequestsExists(int id)
        {
          return (_context.LeaveRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
