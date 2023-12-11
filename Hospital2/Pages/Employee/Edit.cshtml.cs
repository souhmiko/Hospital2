﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital2.Models;

namespace Hospital2.Pages.Employee
{
    public class EditModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public EditModel(Hospital2.Models.Hospital2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public UserDetails UserDetails { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserDetails == null)
            {
                return NotFound();
            }

            var userdetails =  await _context.UserDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (userdetails == null)
            {
                return NotFound();
            }
            UserDetails = userdetails;
           ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "DepartmentName");
           ViewData["WorkTitleId"] = new SelectList(_context.WorkTitles, "Id", "WorkTitleName");
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

            _context.Attach(UserDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailsExists(UserDetails.Id))
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

        private bool UserDetailsExists(int id)
        {
          return (_context.UserDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
