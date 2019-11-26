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
    public class RecursoCambioController : ControllerBase
    {
        private readonly ismddbContext _context;

        public RecursoCambioController(ismddbContext context)
        {
            _context = context;
        }

        // GET: api/RecursoCambio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecursoCambio>>> GetRecursoCambio()
        {
            return await _context.RecursoCambio.ToListAsync();
        }

        // GET: api/RecursoCambio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecursoCambio>> GetRecursoCambio(int id)
        {
            var recursoCambio = await _context.RecursoCambio.FindAsync(id);

            if (recursoCambio == null)
            {
                return NotFound();
            }

            return recursoCambio;
        }

        // PUT: api/RecursoCambio/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecursoCambio(int id, RecursoCambio recursoCambio)
        {
            if (id != recursoCambio.IdRecursoCambio)
            {
                return BadRequest();
            }

            _context.Entry(recursoCambio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoCambioExists(id))
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

        // POST: api/RecursoCambio
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RecursoCambio>> PostRecursoCambio(RecursoCambio recursoCambio)
        {
            _context.RecursoCambio.Add(recursoCambio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecursoCambio", new { id = recursoCambio.IdRecursoCambio }, recursoCambio);
        }

        // DELETE: api/RecursoCambio/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecursoCambio>> DeleteRecursoCambio(int id)
        {
            var recursoCambio = await _context.RecursoCambio.FindAsync(id);
            if (recursoCambio == null)
            {
                return NotFound();
            }

            _context.RecursoCambio.Remove(recursoCambio);
            await _context.SaveChangesAsync();

            return recursoCambio;
        }

        private bool RecursoCambioExists(int id)
        {
            return _context.RecursoCambio.Any(e => e.IdRecursoCambio == id);
        }
    }
}
