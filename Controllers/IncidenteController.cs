using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ismdbackend.Models;

namespace ismdbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenteController : ControllerBase
    {
        private readonly ismddbContext _context;

        public IncidenteController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/Incidente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incidente>>> GetIncidente()
        {
            return await _context.Incidente.ToListAsync();
        }

        // GET: api/Incidente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incidente>> GetIncidente(int id)
        {
            var incidente = await _context.Incidente.FindAsync(id);

            if (incidente == null)
            {
                return NotFound();
            }

            return incidente;
        }

        // PUT: api/Incidente/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidente(int id, Incidente incidente)
        {
            if (id != incidente.IdIncidente)
            {
                return BadRequest();
            }

            _context.Entry(incidente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidenteExists(id))
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

        // POST: api/Incidente
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Incidente>> PostIncidente(Incidente incidente)
        {
            _context.Incidente.Add(incidente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncidente", new { id = incidente.IdIncidente }, incidente);
        }

        // DELETE: api/Incidente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Incidente>> DeleteIncidente(int id)
        {
            var incidente = await _context.Incidente.FindAsync(id);
            if (incidente == null)
            {
                return NotFound();
            }

            _context.Incidente.Remove(incidente);
            await _context.SaveChangesAsync();

            return incidente;
        }

        private bool IncidenteExists(int id)
        {
            return _context.Incidente.Any(e => e.IdIncidente == id);
        }
    }
}
