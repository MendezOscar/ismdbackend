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
    public class RecursoEncabezadoController : ControllerBase
    {
        private readonly ismddbContext _context;

        public RecursoEncabezadoController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/RecursoEncabezado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecursoEncabezado>>> GetRecursoEncabezado()
        {
            return await _context.RecursoEncabezado.ToListAsync();
        }

        // GET: api/RecursoEncabezado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecursoEncabezado>> GetRecursoEncabezado(int id)
        {
            var recursoEncabezado = await _context.RecursoEncabezado.FindAsync(id);

            if (recursoEncabezado == null)
            {
                return NotFound();
            }

            return recursoEncabezado;
        }

        // PUT: api/RecursoEncabezado/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecursoEncabezado(int id, RecursoEncabezado recursoEncabezado)
        {
            if (id != recursoEncabezado.IdRecurso)
            {
                return BadRequest();
            }

            _context.Entry(recursoEncabezado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoEncabezadoExists(id))
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

        // POST: api/RecursoEncabezado
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RecursoEncabezado>> PostRecursoEncabezado(RecursoEncabezado recursoEncabezado)
        {
            _context.RecursoEncabezado.Add(recursoEncabezado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecursoEncabezadoExists(recursoEncabezado.IdRecurso))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecursoEncabezado", new { id = recursoEncabezado.IdRecurso }, recursoEncabezado);
        }

        // DELETE: api/RecursoEncabezado/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecursoEncabezado>> DeleteRecursoEncabezado(int id)
        {
            var recursoEncabezado = await _context.RecursoEncabezado.FindAsync(id);
            if (recursoEncabezado == null)
            {
                return NotFound();
            }

            _context.RecursoEncabezado.Remove(recursoEncabezado);
            await _context.SaveChangesAsync();

            return recursoEncabezado;
        }

        private bool RecursoEncabezadoExists(int id)
        {
            return _context.RecursoEncabezado.Any(e => e.IdRecurso == id);
        }
    }
}
