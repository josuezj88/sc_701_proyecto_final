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
    public class PollitoesController : ControllerBase
    {
        private readonly PollitosContext _context;

        public PollitoesController(PollitosContext context)
        {
            _context = context;
        }

        // GET: api/Pollitoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pollito>>> GetPollito()
        {
            return await _context.Pollito.ToListAsync();
        }

        // GET: api/Pollitoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pollito>> GetPollito(int id)
        {
            var pollito = await _context.Pollito.FindAsync(id);

            if (pollito == null)
            {
                return NotFound();
            }

            return pollito;
        }

        // PUT: api/Pollitoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPollito(int id, Pollito pollito)
        {
            if (id != pollito.CedulaP)
            {
                return BadRequest();
            }

            _context.Entry(pollito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollitoExists(id))
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

        // POST: api/Pollitoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pollito>> PostPollito(Pollito pollito)
        {
            _context.Pollito.Add(pollito);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PollitoExists(pollito.CedulaP))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPollito", new { id = pollito.CedulaP }, pollito);
        }

        // DELETE: api/Pollitoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pollito>> DeletePollito(int id)
        {
            var pollito = await _context.Pollito.FindAsync(id);
            if (pollito == null)
            {
                return NotFound();
            }

            _context.Pollito.Remove(pollito);
            await _context.SaveChangesAsync();

            return pollito;
        }

        private bool PollitoExists(int id)
        {
            return _context.Pollito.Any(e => e.CedulaP == id);
        }
    }
}
