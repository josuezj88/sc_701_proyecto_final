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
    public class DiariosController : ControllerBase
    {
        private readonly PollitosContext _context;

        public DiariosController(PollitosContext context)
        {
            _context = context;
        }

        // GET: api/Diarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diario>>> GetDiario()
        {
            return await _context.Diario.ToListAsync();
        }

        // GET: api/Diarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diario>> GetDiario(int id)
        {
            var diario = await _context.Diario.FindAsync(id);

            if (diario == null)
            {
                return NotFound();
            }

            return diario;
        }

        // PUT: api/Diarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiario(int id, Diario diario)
        {
            if (id != diario.IdArticulo)
            {
                return BadRequest();
            }

            _context.Entry(diario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiarioExists(id))
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

        // POST: api/Diarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Diario>> PostDiario(Diario diario)
        {
            _context.Diario.Add(diario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DiarioExists(diario.IdArticulo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDiario", new { id = diario.IdArticulo }, diario);
        }

        // DELETE: api/Diarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Diario>> DeleteDiario(int id)
        {
            var diario = await _context.Diario.FindAsync(id);
            if (diario == null)
            {
                return NotFound();
            }

            _context.Diario.Remove(diario);
            await _context.SaveChangesAsync();

            return diario;
        }

        private bool DiarioExists(int id)
        {
            return _context.Diario.Any(e => e.IdArticulo == id);
        }
    }
}
