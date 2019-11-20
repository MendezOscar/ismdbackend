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
    public class RecursoDetalleController : ControllerBase
    {
        private readonly ismddbContext _context;

        public RecursoDetalleController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/RecursoDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecursoDetalle>>> GetRecursoDetalle()
        {
            return await _context.RecursoDetalle.ToListAsync();
        }

        // GET: api/RecursoDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecursoDetalle>> GetRecursoDetalle(int id)
        {
            var recursoDetalle = await _context.RecursoDetalle.FindAsync(id);

            if (recursoDetalle == null)
            {
                return NotFound();
            }

            return recursoDetalle;
        }

        // PUT: api/RecursoDetalle/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecursoDetalle(int id, RecursoDetalle recursoDetalle)
        {
            if (id != recursoDetalle.IdRecursoDet)
            {
                return BadRequest();
            }

            _context.Entry(recursoDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoDetalleExists(id))
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

        // POST: api/RecursoDetalle
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RecursoDetalle>> PostRecursoDetalle(RecursoDetalle recursoDetalle)
        {
            _context.RecursoDetalle.Add(recursoDetalle);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecursoDetalleExists(recursoDetalle.IdRecursoDet))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecursoDetalle", new { id = recursoDetalle.IdRecursoDet }, recursoDetalle);
        }

        // DELETE: api/RecursoDetalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecursoDetalle>> DeleteRecursoDetalle(int id)
        {
            var recursoDetalle = await _context.RecursoDetalle.FindAsync(id);
            if (recursoDetalle == null)
            {
                return NotFound();
            }

            _context.RecursoDetalle.Remove(recursoDetalle);
            await _context.SaveChangesAsync();

            return recursoDetalle;
        }

        private bool RecursoDetalleExists(int id)
        {
            return _context.RecursoDetalle.Any(e => e.IdRecursoDet == id);
        }
    }
}
