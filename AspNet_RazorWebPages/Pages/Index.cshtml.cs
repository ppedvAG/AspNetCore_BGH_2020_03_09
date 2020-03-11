using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AspNet_RazorWebPages.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AspNet_RazorWebPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            HttpContext.Session.SetString("HappyHour", "23");

            Aufgaben aufgabe = new Aufgaben();
            aufgabe.Id = 1;
            aufgabe.Text = "Wir gehen Mittagsessen";
            aufgabe.DeadlineDatum = DateTime.Now;
            aufgabe.AufgabeFertig = true;


            string jsonString = JsonSerializer.Serialize(aufgabe);
            HttpContext.Session.SetString("currentAufgabe", jsonString);
        }
    }
}
