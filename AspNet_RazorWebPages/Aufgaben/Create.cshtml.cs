using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNet_RazorWebPages.Data;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AspNet_RazorWebPages.RazorCrud
{
    public class CreateModel : PageModel
    {
        private readonly AspNet_RazorWebPages.Data.AufgabenContext _context;

        public CreateModel(AspNet_RazorWebPages.Data.AufgabenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Aufgaben Aufgaben { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // https://localhost:44349/api/Aufgaben

            var json = JsonConvert.SerializeObject(Aufgaben);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://localhost:44349/api/Aufgabens";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;

            return RedirectToPage("./Index");
        }
    }
}
