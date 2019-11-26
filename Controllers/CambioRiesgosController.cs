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
    public class CambioRiesgosController : ControllerBase
    {
        private readonly ismddbContext _context;

        public CambioRiesgosController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/CambioRiesgos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CambioRiesgos>>> GetCambioRiesgos()
        {
            return await _context.CambioRiesgos.ToListAsync();
        }

        // GET: api/CambioRiesgos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CambioRiesgos>> GetCambioRiesgos(int id)
        {
            var cambioRiesgos = await _context.CambioRiesgos.FindAsync(id);

            if (cambioRiesgos == null)
            {
                return NotFound();
            }

            return cambioRiesgos;
        }

        // PUT: api/CambioRiesgos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCambioRiesgos(int id, CambioRiesgos cambioRiesgos)
        {
            if (id != cambioRiesgos.IdCambioRiego)
            {
                return BadRequest();
            }

            _context.Entry(cambioRiesgos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CambioRiesgosExists(id))
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

        // POST: api/CambioRiesgos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CambioRiesgos>> PostCambioRiesgos(CambioRiesgos cambioRiesgos)
        {
            _context.CambioRiesgos.Add(cambioRiesgos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCambioRiesgos", new { id = cambioRiesgos.IdCambioRiego }, cambioRiesgos);
        }

        // DELETE: api/CambioRiesgos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CambioRiesgos>> DeleteCambioRiesgos(int id)
        {
            var cambioRiesgos = await _context.CambioRiesgos.FindAsync(id);
            if (cambioRiesgos == null)
            {
                return NotFound();
            }

            _context.CambioRiesgos.Remove(cambioRiesgos);
            await _context.SaveChangesAsync();

            return cambioRiesgos;
        }

        private bool CambioRiesgosExists(int id)
        {
            return _context.CambioRiesgos.Any(e => e.IdCambioRiego == id);
        }
    }
}
