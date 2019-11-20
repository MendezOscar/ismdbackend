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
    public class CapacidadController : ControllerBase
    {
        private readonly ismddbContext _context;

        public CapacidadController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/Capacidad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Capacidad>>> GetCapacidad()
        {
            return await _context.Capacidad.ToListAsync();
        }

        // GET: api/Capacidad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capacidad>> GetCapacidad(int id)
        {
            var capacidad = await _context.Capacidad.FindAsync(id);

            if (capacidad == null)
            {
                return NotFound();
            }

            return capacidad;
        }

        // PUT: api/Capacidad/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapacidad(int id, Capacidad capacidad)
        {
            if (id != capacidad.IdCapacidad)
            {
                return BadRequest();
            }

            _context.Entry(capacidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapacidadExists(id))
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

        // POST: api/Capacidad
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Capacidad>> PostCapacidad(Capacidad capacidad)
        {
            _context.Capacidad.Add(capacidad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CapacidadExists(capacidad.IdCapacidad))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCapacidad", new { id = capacidad.IdCapacidad }, capacidad);
        }

        // DELETE: api/Capacidad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Capacidad>> DeleteCapacidad(int id)
        {
            var capacidad = await _context.Capacidad.FindAsync(id);
            if (capacidad == null)
            {
                return NotFound();
            }

            _context.Capacidad.Remove(capacidad);
            await _context.SaveChangesAsync();

            return capacidad;
        }

        private bool CapacidadExists(int id)
        {
            return _context.Capacidad.Any(e => e.IdCapacidad == id);
        }
    }
}
