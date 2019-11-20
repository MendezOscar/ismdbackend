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
    public class CatalogoClienteController : ControllerBase
    {
        private readonly ismddbContext _context;

        public CatalogoClienteController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/CatalogoCliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogoCliente>>> GetCatalogoCliente()
        {
            return await _context.CatalogoCliente.ToListAsync();
        }

        // GET: api/CatalogoCliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogoCliente>> GetCatalogoCliente(int id)
        {
            var catalogoCliente = await _context.CatalogoCliente.FindAsync(id);

            if (catalogoCliente == null)
            {
                return NotFound();
            }

            return catalogoCliente;
        }

        // PUT: api/CatalogoCliente/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogoCliente(int id, CatalogoCliente catalogoCliente)
        {
            if (id != catalogoCliente.IdCatalogoCliente)
            {
                return BadRequest();
            }

            _context.Entry(catalogoCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogoClienteExists(id))
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

        // POST: api/CatalogoCliente
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CatalogoCliente>> PostCatalogoCliente(CatalogoCliente catalogoCliente)
        {
            _context.CatalogoCliente.Add(catalogoCliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CatalogoClienteExists(catalogoCliente.IdCatalogoCliente))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCatalogoCliente", new { id = catalogoCliente.IdCatalogoCliente }, catalogoCliente);
        }

        // DELETE: api/CatalogoCliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatalogoCliente>> DeleteCatalogoCliente(int id)
        {
            var catalogoCliente = await _context.CatalogoCliente.FindAsync(id);
            if (catalogoCliente == null)
            {
                return NotFound();
            }

            _context.CatalogoCliente.Remove(catalogoCliente);
            await _context.SaveChangesAsync();

            return catalogoCliente;
        }

        private bool CatalogoClienteExists(int id)
        {
            return _context.CatalogoCliente.Any(e => e.IdCatalogoCliente == id);
        }
    }
}
