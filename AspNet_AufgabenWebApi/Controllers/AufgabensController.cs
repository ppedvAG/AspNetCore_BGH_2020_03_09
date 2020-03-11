using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNet_AufgabenWebApi.Data;

namespace AspNet_AufgabenWebApi.Controllers
{

    // Weitere Themen: Hateoas -> https://code-maze.com/hateoas-aspnet-core-web-api/

    [Route("api/[controller]")]
    [ApiController]
    public class AufgabensController : ControllerBase
    {
        private readonly AufgabenContext _context;

        public AufgabensController(AufgabenContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Rock Me Amadeus - >  GET: api/Aufgabens
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aufgaben>>> GetAufgaben()
        {
            return await _context.Aufgaben.ToListAsync();
        }

        // GET: api/Aufgabens/5

        /// <summary>
        /// HAllejulia 
        /// </summary>
        /// <param name="id">Id der Aufgabe wird übergeben</param>
        /// <returns>Du bekommst einen Task zurück</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Aufgaben>> GetAufgaben(int id)
        {
            var aufgaben = await _context.Aufgaben.FindAsync(id);

            if (aufgaben == null)
            {
                return NotFound();
            }

            return aufgaben;
        }

        // PUT: api/Aufgabens/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAufgaben(int id, Aufgaben aufgaben)
        {
            if (id != aufgaben.Id)
            {
                return BadRequest();
            }

            _context.Entry(aufgaben).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AufgabenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        /// <summary>Ich kann via GhostDoc mein Kommentar auch bearbeiten</summary>
        /// <param name="aufgaben">Cool sogar Parameter kann ich Kommentar...alles via Ghost Doc</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Aufgaben>> PostAufgaben(Aufgaben aufgaben)
        {
            _context.Aufgaben.Add(aufgaben);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAufgaben", new { id = aufgaben.Id }, aufgaben);
        }

        // DELETE: api/Aufgabens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aufgaben>> DeleteAufgaben(int id)
        {
            var aufgaben = await _context.Aufgaben.FindAsync(id);
            if (aufgaben == null)
            {
                return NotFound();
            }

            _context.Aufgaben.Remove(aufgaben);
            await _context.SaveChangesAsync();

            return aufgaben;
        }

        private bool AufgabenExists(int id)
        {
            return _context.Aufgaben.Any(e => e.Id == id);
        }
    }
}
