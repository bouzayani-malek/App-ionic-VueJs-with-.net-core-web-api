using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProjet.Models;

namespace MiniProjet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivresController : ControllerBase
    {
        private readonly MiniProjetContext _context;
        public IHostingEnvironment hostingEnvironement;

        public LivresController(MiniProjetContext context, IHostingEnvironment hosting)
        {
            _context = context;
            hostingEnvironement = hosting;
        }

        // GET: api/Livres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livre>>> GetLivre()
        {
            //return await _context.Livre.ToListAsync();
            List<Livre> livres = _context.Livre.ToList();
            foreach (Livre L in livres)
            {
                _context.Entry(L)
                        .Collection(s => s.Empreint)
                        .Load();
            }
            return livres;
        }

        // GET: api/Livres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livre>> GetLivre(int id)
        {
            // var livre = await _context.Livre.FindAsync(id);
            var livre = await _context.Livre.SingleAsync(etd => etd.IdLivre == id);
            _context.Entry(livre)
                    .Collection(s => s.Empreint)
                    .Load();
            if (livre == null)
            {
                return NotFound();
            }

            return livre;
        }

        // PUT: api/Livres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivre(int id, Livre livre)
        {
            if (id != livre.IdLivre)
            {
                return BadRequest();
            }

            _context.Entry(livre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivreExists(id))
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
        //ajouter image
        [HttpPost("Image")]
        public async Task<ActionResult<String>> Ajouter()
        {
            //ajouter livre   
             var files = HttpContext.Request.Form.Files[0];


                      FileInfo fi = new FileInfo(files.FileName);
            var newfilename = "image" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
            var path = Path.Combine("", hostingEnvironement.ContentRootPath + "/image/" + newfilename);
                      using (var stream = new FileStream(path, FileMode.Create))
                      {
                          files.CopyTo(stream);
                      }





            return newfilename;
        }
        // POST: api/Livres
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Livre>> PostLivre(Livre livre)
        {
            _context.Livre.Add(livre);
           await _context.SaveChangesAsync();
           return CreatedAtAction("GetLivre", new { id = livre.IdLivre }, livre);
        }

        // DELETE: api/Livres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Livre>> DeleteLivre(int id)
        {
            var livre = await _context.Livre.FindAsync(id);
            if (livre == null)
            {
                return NotFound();
            }

            _context.Livre.Remove(livre);
            await _context.SaveChangesAsync();

            return livre;
        }

        private bool LivreExists(int id)
        {
            return _context.Livre.Any(e => e.IdLivre == id);
        }
    }
}
