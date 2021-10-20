using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class NoticiasController : ControllerBase
    {
        private readonly PollitosContext _context;

        public NoticiasController(PollitosContext context)
        {
            _context = context;
        }

        // GET: api/Noticias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Noticias>>> GetNoticias()
        {
            return await _context.Noticias.ToListAsync();
        }

        // GET: api/Noticias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Noticias>> GetNoticias(int id)
        {
            var noticias = await _context.Noticias.FindAsync(id);

            if (noticias == null)
            {
                return NotFound();
            }

            return noticias;
        }

        // PUT: api/Noticias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoticias(int id, Noticias noticias)
        {
            if (id != noticias.IdNoticias)
            {
                return BadRequest();
            }

            _context.Entry(noticias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiasExists(id))
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

        // POST: api/Noticias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Noticias>> PostNoticias(Noticias noticias)
        {
            _context.Noticias.Add(noticias);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NoticiasExists(noticias.IdNoticias))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNoticias", new { id = noticias.IdNoticias }, noticias);
        }

        // DELETE: api/Noticias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Noticias>> DeleteNoticias(int id)
        {
            var noticias = await _context.Noticias.FindAsync(id);
            if (noticias == null)
            {
                return NotFound();
            }

            _context.Noticias.Remove(noticias);
            await _context.SaveChangesAsync();

            return noticias;
        }

        private bool NoticiasExists(int id)
        {
            return _context.Noticias.Any(e => e.IdNoticias == id);
        }
    }
}
