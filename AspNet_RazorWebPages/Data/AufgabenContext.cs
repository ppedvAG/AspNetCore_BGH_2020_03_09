using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNet_RazorWebPages.Data
{
    public class AufgabenContext : DbContext
    {
        public AufgabenContext (DbContextOptions<AufgabenContext> options)
            : base(options)
        {
        }

        public DbSet<AspNet_RazorWebPages.Data.Aufgaben> Aufgaben { get; set; }
    }
}
