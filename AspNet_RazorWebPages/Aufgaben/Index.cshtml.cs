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
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44349/api/Aufgaben/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Aufgaben = JsonConvert.DeserializeObject<List<Aufgaben>>(apiResponse);
                }
            }
        }
    }
}
