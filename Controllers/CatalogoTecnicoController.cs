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
    public class CatalogoTecnicoController : ControllerBase
    {
        private readonly ismddbContext _context;

        public CatalogoTecnicoController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/CatalogoTecnico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogoTecnico>>> GetCatalogoTecnico()
        {
            return await _context.CatalogoTecnico.ToListAsync();
        }

        // GET: api/CatalogoTecnico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogoTecnico>> GetCatalogoTecnico(int id)
        {
            var catalogoTecnico = await _context.CatalogoTecnico.FindAsync(id);

            if (catalogoTecnico == null)
            {
                return NotFound();
            }

            return catalogoTecnico;
        }

        // PUT: api/CatalogoTecnico/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogoTecnico(int id, CatalogoTecnico catalogoTecnico)
        {
            if (id != catalogoTecnico.IdCatalogoTec)
            {
                return BadRequest();
            }

            _context.Entry(catalogoTecnico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogoTecnicoExists(id))
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

        // POST: api/CatalogoTecnico
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CatalogoTecnico>> PostCatalogoTecnico(CatalogoTecnico catalogoTecnico)
        {
            _context.CatalogoTecnico.Add(catalogoTecnico);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CatalogoTecnicoExists(catalogoTecnico.IdCatalogoTec))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCatalogoTecnico", new { id = catalogoTecnico.IdCatalogoTec }, catalogoTecnico);
        }

        // DELETE: api/CatalogoTecnico/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatalogoTecnico>> DeleteCatalogoTecnico(int id)
        {
            var catalogoTecnico = await _context.CatalogoTecnico.FindAsync(id);
            if (catalogoTecnico == null)
            {
                return NotFound();
            }

            _context.CatalogoTecnico.Remove(catalogoTecnico);
            await _context.SaveChangesAsync();

            return catalogoTecnico;
        }

        private bool CatalogoTecnicoExists(int id)
        {
            return _context.CatalogoTecnico.Any(e => e.IdCatalogoTec == id);
        }
    }
}
