using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNet_RazorWebPages.Data;
using System.Net.Http;
using Newtonsoft.Json;

namespace AspNet_RazorWebPages.RazorCrud
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
    }
}
