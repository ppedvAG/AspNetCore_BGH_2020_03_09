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
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string happyString = HttpContext.Session.GetString("HappyHour");

            string jsonString = HttpContext.Session.GetString("currentAufgabe");

            Aufgaben aufgaben = JsonSerializer.Deserialize<Aufgaben>(jsonString);
        }
    }
}
