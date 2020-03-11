using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNet_RazorWebPages.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace AspNet_RazorWebPages.RazorCrud
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

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44349/api/Aufgaben/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Aufgaben = JsonConvert.DeserializeObject<Aufgaben>(apiResponse);
                }
            }

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

            var json = JsonConvert.SerializeObject(Aufgaben);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://localhost:44349/api/Aufgaben/" + Aufgaben.Id;
            using var client = new HttpClient();

            var response = await client.PutAsync(url, data); //api/Aufgabens/5

            string result = response.Content.ReadAsStringAsync().Result;

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
