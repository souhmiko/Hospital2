using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital2.Models;

namespace Hospital2.Pages.WorkTitle
{
    public class EditModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public EditModel(Hospital2.Models.Hospital2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public WorkTitles WorkTitles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.WorkTitles == null)
            {
                return NotFound();
            }

            var worktitles =  await _context.WorkTitles.FirstOrDefaultAsync(m => m.Id == id);
            if (worktitles == null)
            {
                return NotFound();
            }
            WorkTitles = worktitles;
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

            _context.Attach(WorkTitles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkTitlesExists(WorkTitles.Id))
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

        private bool WorkTitlesExists(int id)
        {
          return (_context.WorkTitles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
