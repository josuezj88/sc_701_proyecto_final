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
    public class DistritoesController : ControllerBase
    {
        private readonly PollitosContext _context;

        public DistritoesController(PollitosContext context)
        {
            _context = context;
        }

        // GET: api/Distritoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distrito>>> GetDistrito()
        {
            return await _context.Distrito.ToListAsync();
        }

        // GET: api/Distritoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Distrito>> GetDistrito(int id)
        {
            var distrito = await _context.Distrito.FindAsync(id);

            if (distrito == null)
            {
                return NotFound();
            }

            return distrito;
        }

        // PUT: api/Distritoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistrito(int id, Distrito distrito)
        {
            if (id != distrito.IdDistrito)
            {
                return BadRequest();
            }

            _context.Entry(distrito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistritoExists(id))
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

        // POST: api/Distritoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Distrito>> PostDistrito(Distrito distrito)
        {
            _context.Distrito.Add(distrito);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DistritoExists(distrito.IdDistrito))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDistrito", new { id = distrito.IdDistrito }, distrito);
        }

        // DELETE: api/Distritoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Distrito>> DeleteDistrito(int id)
        {
            var distrito = await _context.Distrito.FindAsync(id);
            if (distrito == null)
            {
                return NotFound();
            }

            _context.Distrito.Remove(distrito);
            await _context.SaveChangesAsync();

            return distrito;
        }

        private bool DistritoExists(int id)
        {
            return _context.Distrito.Any(e => e.IdDistrito == id);
        }
    }
}
