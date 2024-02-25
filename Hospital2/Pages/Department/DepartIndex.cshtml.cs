using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hospital2.Models;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout;


namespace Hospital2.Pages.test
{
    public class IndexModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;

        public IndexModel(Hospital2.Models.Hospital2Context context)
        {
            _context = context;
        }

        public IList<Departments> Departments { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Departments != null)
            {
                Departments = await _context.Departments.ToListAsync();
            }
        }


        public async Task<IActionResult> OnPostExportToPdfAsync()
        {
            if (Departments == null || Departments.Count == 0)
            {
                Departments = await _context.Departments.ToListAsync();
            }

            using (var stream = new MemoryStream())
            {
                using (var writer = new PdfWriter(stream))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);
                        document.Add(new Paragraph("Departments").SetFontSize(14).SetBold());

                        Table table = new Table(UnitValue.CreatePercentArray(new float[] { 2, 2, 2, 2, 1, 1 })).UseAllAvailableWidth();
                        table.AddHeaderCell("Department Name");
                        

                        foreach (var comp in Departments)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(comp.DepartmentName)));
                            
                        }

                        document.Add(table);
                        document.Close();
                    }
                }
                return File(stream.ToArray(), "application/pdf", "Departments.pdf");
            }
        }

    }
}
