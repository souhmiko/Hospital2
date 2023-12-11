using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hospital2.Models;

namespace Hospital2.Pages.WorkTitle
{
    public class IndexModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public IndexModel(Hospital2.Models.Hospital2Context context)
        {
            _context = context;
        }

        public IList<WorkTitles> WorkTitles { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.WorkTitles != null)
            {
                WorkTitles = await _context.WorkTitles.ToListAsync();
            }
        }
    }
}
