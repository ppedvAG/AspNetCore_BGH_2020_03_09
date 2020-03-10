using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNet_RazorWebPages
{
    public class IndexAModel : PageModel
    {
        public int MyProperty { get; set; }
        public void OnGet()
        {
            MyProperty = 7;
        }
    }
}