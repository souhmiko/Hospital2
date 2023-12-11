using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hospital2.Models;

namespace Hospital2.Pages.OncallReq
{
    public class CreateModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public CreateModel(Hospital2.Models.Hospital2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id");
        ViewData["LeaveStatusId"] = new SelectList(_context.LeaveStatus, "Id", "Id");
        ViewData["UserDetailId"] = new SelectList(_context.UserDetails, "Id", "AspNetUserId");
            return Page();
        }

        [BindProperty]
        public OncallRequests OncallRequests { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.OncallRequests == null || OncallRequests == null)
            {
                return Page();
            }

            _context.OncallRequests.Add(OncallRequests);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
