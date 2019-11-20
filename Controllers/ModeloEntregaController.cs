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
    public class ModeloEntregaController : ControllerBase
    {
        private readonly ismddbContext _context;

        public ModeloEntregaController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/ModeloEntrega
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeloEntrega>>> GetModeloEntrega()
        {
            return await _context.ModeloEntrega.ToListAsync();
        }

        // GET: api/ModeloEntrega/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModeloEntrega>> GetModeloEntrega(int id)
        {
            var modeloEntrega = await _context.ModeloEntrega.FindAsync(id);

            if (modeloEntrega == null)
            {
                return NotFound();
            }

            return modeloEntrega;
        }

        // PUT: api/ModeloEntrega/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModeloEntrega(int id, ModeloEntrega modeloEntrega)
        {
            if (id != modeloEntrega.IdModelo)
            {
                return BadRequest();
            }

            _context.Entry(modeloEntrega).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloEntregaExists(id))
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

        // POST: api/ModeloEntrega
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ModeloEntrega>> PostModeloEntrega(ModeloEntrega modeloEntrega)
        {
            _context.ModeloEntrega.Add(modeloEntrega);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModeloEntregaExists(modeloEntrega.IdModelo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModeloEntrega", new { id = modeloEntrega.IdModelo }, modeloEntrega);
        }

        // DELETE: api/ModeloEntrega/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ModeloEntrega>> DeleteModeloEntrega(int id)
        {
            var modeloEntrega = await _context.ModeloEntrega.FindAsync(id);
            if (modeloEntrega == null)
            {
                return NotFound();
            }

            _context.ModeloEntrega.Remove(modeloEntrega);
            await _context.SaveChangesAsync();

            return modeloEntrega;
        }

        private bool ModeloEntregaExists(int id)
        {
            return _context.ModeloEntrega.Any(e => e.IdModelo == id);
        }
    }
}
