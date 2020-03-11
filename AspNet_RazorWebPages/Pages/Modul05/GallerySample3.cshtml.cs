using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNet_RazorWebPages
{
    public class GallerySample3Model : PageModel
    {

        public string[] Bilder { get; set; }
        public void OnGet()
        {
            var pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\";

            // var c = Path.GetFileName("");

            Bilder = Directory.GetFiles(pfad);
        }
    }
}