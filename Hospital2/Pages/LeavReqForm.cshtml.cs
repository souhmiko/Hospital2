using Hospital2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Hospital2.Pages
{
    public class LeavReqFormModel : PageModel
    {
        private readonly Hospital2Context _context;

        public LeavReqFormModel(Hospital2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public LeaveRequests LeaveRequest { get; set; }

        public IActionResult OnGet()
        {
            // Optional: Add logic for handling GET requests
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, redisplay the form
                return Page();
            }

            // Set additional properties before saving to the database
            //LeaveRequest.LeaveStatus = "Pending";
            //LeaveRequest.UserDetail = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            LeaveRequest.UserDetail = await _context.UserDetails.FindAsync(LeaveRequest.UserDetailId);

            // Save the leave request to the database
            _context.LeaveRequests.Add(LeaveRequest);
            await _context.SaveChangesAsync();

            // Redirect to a confirmation page or dashboard
            return RedirectToPage("/Confirmation");
        }
    }
}
