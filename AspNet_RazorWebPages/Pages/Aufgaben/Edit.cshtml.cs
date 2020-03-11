using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNet_RazorWebPages.Data;

namespace AspNet_RazorWebPages
{
    public class EditModel : PageModel
    {
        private readonly AspNet_RazorWebPages.Data.AufgabenContext _context;

        public EditModel(AspNet_RazorWebPages.Data.AufgabenContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Aufgaben).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AufgabenExists(Aufgaben.Id))
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

        private bool AufgabenExists(int id)
        {
            return _context.Aufgaben.Any(e => e.Id == id);
        }
    }
}
