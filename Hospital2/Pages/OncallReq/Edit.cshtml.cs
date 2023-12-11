using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital2.Models;

namespace Hospital2.Pages.OncallReq
{
    public class EditModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public EditModel(Hospital2.Models.Hospital2Context context)
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

            var oncallrequests =  await _context.OncallRequests.FirstOrDefaultAsync(m => m.Id == id);
            if (oncallrequests == null)
            {
                return NotFound();
            }
            OncallRequests = oncallrequests;
           ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id");
           ViewData["LeaveStatusId"] = new SelectList(_context.LeaveStatus, "Id", "Id");
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

            _context.Attach(OncallRequests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OncallRequestsExists(OncallRequests.Id))
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

        private bool OncallRequestsExists(int id)
        {
          return (_context.OncallRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
