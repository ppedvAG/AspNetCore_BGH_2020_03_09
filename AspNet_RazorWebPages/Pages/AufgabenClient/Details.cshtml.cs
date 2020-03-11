using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNet_RazorWebPages.Data;

namespace AspNet_RazorWebPages.AufgabenClient
{
    public class DetailsModel : PageModel
    {
        private readonly AspNet_RazorWebPages.Data.AufgabenContext _context;

        public DetailsModel(AspNet_RazorWebPages.Data.AufgabenContext context)
        {
            _context = context;
        }

        public Aufgaben Aufgaben { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Aufgaben = await _context.Aufgaben.FirstOrDefaultAsync(m => m.Id == id);

            if (Aufgaben == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
