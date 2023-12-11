﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hospital2.Models;

namespace Hospital2.Pages.test
{
    public class DeleteModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public DeleteModel(Hospital2.Models.Hospital2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Departments Departments { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments.FirstOrDefaultAsync(m => m.Id == id);

            if (departments == null)
            {
                return NotFound();
            }
            else 
            {
                Departments = departments;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }
            var departments = await _context.Departments.FindAsync(id);

            if (departments != null)
            {
                Departments = departments;
                _context.Departments.Remove(Departments);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
