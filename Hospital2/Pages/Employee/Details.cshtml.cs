﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hospital2.Models;

namespace Hospital2.Pages.Employee
{
    public class DetailsModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public DetailsModel(Hospital2.Models.Hospital2Context context)
        {
            _context = context;
        }

      public UserDetails UserDetails { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserDetails == null)
            {
                return NotFound();
            }

            var userdetails = await _context.UserDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (userdetails == null)
            {
                return NotFound();
            }
            else 
            {
                UserDetails = userdetails;
            }
            return Page();
        }
    }
}
