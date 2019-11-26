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
    public class CambiosController : ControllerBase
    {
        private readonly ismddbContext _context;

        public CambiosController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/Cambios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cambios>>> GetCambios()
        {
            return await _context.Cambios.ToListAsync();
        }

        // GET: api/Cambios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cambios>> GetCambios(int id)
        {
            var cambios = await _context.Cambios.FindAsync(id);

            if (cambios == null)
            {
                return NotFound();
            }

            return cambios;
        }

        // PUT: api/Cambios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCambios(int id, Cambios cambios)
        {
            if (id != cambios.IdCambio)
            {
                return BadRequest();
            }

            _context.Entry(cambios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CambiosExists(id))
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

        // POST: api/Cambios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cambios>> PostCambios(Cambios cambios)
        {
            _context.Cambios.Add(cambios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCambios", new { id = cambios.IdCambio }, cambios);
        }

        // DELETE: api/Cambios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cambios>> DeleteCambios(int id)
        {
            var cambios = await _context.Cambios.FindAsync(id);
            if (cambios == null)
            {
                return NotFound();
            }

            _context.Cambios.Remove(cambios);
            await _context.SaveChangesAsync();

            return cambios;
        }

        private bool CambiosExists(int id)
        {
            return _context.Cambios.Any(e => e.IdCambio == id);
        }
    }
}
