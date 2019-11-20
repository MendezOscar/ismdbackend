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
    public class RiesgoController : ControllerBase
    {
        private readonly ismddbContext _context;

        public RiesgoController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/Riesgo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Riesgo>>> GetRiesgo()
        {
            return await _context.Riesgo.ToListAsync();
        }

        // GET: api/Riesgo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Riesgo>> GetRiesgo(int id)
        {
            var riesgo = await _context.Riesgo.FindAsync(id);

            if (riesgo == null)
            {
                return NotFound();
            }

            return riesgo;
        }

        // PUT: api/Riesgo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRiesgo(int id, Riesgo riesgo)
        {
            if (id != riesgo.IdRiesgo)
            {
                return BadRequest();
            }

            _context.Entry(riesgo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiesgoExists(id))
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

        // POST: api/Riesgo
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Riesgo>> PostRiesgo(Riesgo riesgo)
        {
            _context.Riesgo.Add(riesgo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RiesgoExists(riesgo.IdRiesgo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRiesgo", new { id = riesgo.IdRiesgo }, riesgo);
        }

        // DELETE: api/Riesgo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Riesgo>> DeleteRiesgo(int id)
        {
            var riesgo = await _context.Riesgo.FindAsync(id);
            if (riesgo == null)
            {
                return NotFound();
            }

            _context.Riesgo.Remove(riesgo);
            await _context.SaveChangesAsync();

            return riesgo;
        }

        private bool RiesgoExists(int id)
        {
            return _context.Riesgo.Any(e => e.IdRiesgo == id);
        }
    }
}
