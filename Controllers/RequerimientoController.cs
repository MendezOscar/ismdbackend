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
    public class RequerimientoController : ControllerBase
    {
        private readonly ismddbContext _context;

        public RequerimientoController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/Requerimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requerimiento>>> GetRequerimiento()
        {
            return await _context.Requerimiento.ToListAsync();
        }

        // GET: api/Requerimiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requerimiento>> GetRequerimiento(int id)
        {
            var requerimiento = await _context.Requerimiento.FindAsync(id);

            if (requerimiento == null)
            {
                return NotFound();
            }

            return requerimiento;
        }

        // PUT: api/Requerimiento/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequerimiento(int id, Requerimiento requerimiento)
        {
            if (id != requerimiento.IdRequerimiento)
            {
                return BadRequest();
            }

            _context.Entry(requerimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequerimientoExists(id))
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

        // POST: api/Requerimiento
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Requerimiento>> PostRequerimiento(Requerimiento requerimiento)
        {
            _context.Requerimiento.Add(requerimiento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RequerimientoExists(requerimiento.IdRequerimiento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRequerimiento", new { id = requerimiento.IdRequerimiento }, requerimiento);
        }

        // DELETE: api/Requerimiento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Requerimiento>> DeleteRequerimiento(int id)
        {
            var requerimiento = await _context.Requerimiento.FindAsync(id);
            if (requerimiento == null)
            {
                return NotFound();
            }

            _context.Requerimiento.Remove(requerimiento);
            await _context.SaveChangesAsync();

            return requerimiento;
        }

        private bool RequerimientoExists(int id)
        {
            return _context.Requerimiento.Any(e => e.IdRequerimiento == id);
        }
    }
}
