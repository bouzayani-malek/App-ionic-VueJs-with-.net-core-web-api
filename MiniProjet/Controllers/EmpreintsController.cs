using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProjet.Models;

namespace MiniProjet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpreintsController : ControllerBase
    {
        private readonly MiniProjetContext _context;

        public EmpreintsController(MiniProjetContext context)
        {
            _context = context;
        }

        // GET: api/Empreints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empreint>>> GetEmpreint()
        {
            return await _context.Empreint.ToListAsync();
        }

        // GET: api/Empreints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empreint>> GetEmpreint(int id)
        {
            var empreint = await _context.Empreint.FindAsync(id);

            if (empreint == null)
            {
                return NotFound();
            }

            return empreint;
        }

        // PUT: api/Empreints/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpreint(int id, Empreint empreint)
        {
            if (id != empreint.IdEmpreinte)
            {
                return BadRequest();
            }

            _context.Entry(empreint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpreintExists(id))
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

        // POST: api/Empreints
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Empreint>> PostEmpreint(Empreint empreint)
        {
            _context.Empreint.Add(empreint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpreint", new { id = empreint.IdEmpreinte }, empreint);
        }

        // DELETE: api/Empreints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empreint>> DeleteEmpreint(int id)
        {
            var empreint = await _context.Empreint.FindAsync(id);
            if (empreint == null)
            {
                return NotFound();
            }

            _context.Empreint.Remove(empreint);
            await _context.SaveChangesAsync();

            return empreint;
        }

        private bool EmpreintExists(int id)
        {
            return _context.Empreint.Any(e => e.IdEmpreinte == id);
        }
    }
}
