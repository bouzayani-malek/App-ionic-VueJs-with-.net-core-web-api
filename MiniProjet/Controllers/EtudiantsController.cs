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
    public class EtudiantsController : ControllerBase
    {
        private readonly MiniProjetContext _context;

        public EtudiantsController(MiniProjetContext context)
        {
            _context = context;
        }

        // GET: api/Etudiants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etudiant>>> GetEtudiant()
        {
            List<Etudiant> Etudiants = _context.Etudiant.ToList();
            foreach(Etudiant E in Etudiants)
            {
                _context.Entry(E)
                        .Collection(s => s.Empreint)
                        .Load();
            }
            return Etudiants;
        }

        // GET: api/Etudiants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etudiant>> GetEtudiant(int id)
        {
            //  var etudiant = await _context.Etudiant.FindAsync(id);
            var etudiant = await _context.Etudiant.SingleAsync(etd => etd.IdEtudiant == id);
            _context.Entry(etudiant)
                    .Collection(s => s.Empreint)
                    .Load();
            if (etudiant == null)
            {
                return NotFound("NotFound");
            }

            return etudiant;
        }

        // PUT: api/Etudiants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtudiant(int id, Etudiant etudiant)
        {
            if (id != etudiant.IdEtudiant)
            {
                return BadRequest();
            }

            _context.Entry(etudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(id))
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

        // POST: api/Etudiants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Etudiant>> PostEtudiant(Etudiant etudiant)
        {
            _context.Etudiant.Add(etudiant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtudiant", new { id = etudiant.IdEtudiant }, etudiant);
        }

        // DELETE: api/Etudiants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Etudiant>> DeleteEtudiant(int id)
        {
            var etudiant = await _context.Etudiant.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            _context.Etudiant.Remove(etudiant);
            await _context.SaveChangesAsync();

            return etudiant;
        }

        private bool EtudiantExists(int id)
        {
            return _context.Etudiant.Any(e => e.IdEtudiant == id);
        }
    }
}
