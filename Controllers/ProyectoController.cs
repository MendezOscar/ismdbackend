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
    public class ProyectoController : ControllerBase
    {
        private readonly ismddbContext _context;

        public ProyectoController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/Proyecto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyecto()
        {
            return await _context.Proyecto.ToListAsync();
        }

        // GET: api/Proyecto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetProyecto(int id)
        {
            var proyecto = await _context.Proyecto.FindAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return proyecto;
        }

        // PUT: api/Proyecto/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(int id, Proyecto proyecto)
        {
            if (id != proyecto.IdProyecto)
            {
                return BadRequest();
            }

            _context.Entry(proyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoExists(id))
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

        // POST: api/Proyecto
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Proyecto>> PostProyecto(Proyecto proyecto)
        {
            _context.Proyecto.Add(proyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyecto", new { id = proyecto.IdProyecto }, proyecto);
        }

        // DELETE: api/Proyecto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proyecto>> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyecto.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }

            _context.Proyecto.Remove(proyecto);
            await _context.SaveChangesAsync();

            return proyecto;
        }

        private bool ProyectoExists(int id)
        {
            return _context.Proyecto.Any(e => e.IdProyecto == id);
        }
    }
}
