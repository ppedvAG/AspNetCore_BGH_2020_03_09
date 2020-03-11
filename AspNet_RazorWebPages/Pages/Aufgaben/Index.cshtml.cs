using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNet_RazorWebPages.Data;

namespace AspNet_RazorWebPages
{
    public class IndexModel : PageModel
    {
        private readonly AspNet_RazorWebPages.Data.AufgabenContext _context;

        public IndexModel(AspNet_RazorWebPages.Data.AufgabenContext context)
        {
            _context = context;
        }

        public IList<Aufgaben> Aufgaben { get;set; }

        public async Task OnGetAsync()
        {
            Aufgaben = await _context.Aufgaben.ToListAsync();
        }
    }
}
