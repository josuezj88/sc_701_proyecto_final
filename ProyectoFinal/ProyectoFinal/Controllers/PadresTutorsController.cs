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
    public class PadresTutorsController : ControllerBase
    {
        private readonly PollitosContext _context;

        public PadresTutorsController(PollitosContext context)
        {
            _context = context;
        }

        // GET: api/PadresTutors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PadresTutor>>> GetPadresTutor()
        {
            return await _context.PadresTutor.ToListAsync();
        }

        // GET: api/PadresTutors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PadresTutor>> GetPadresTutor(int id)
        {
            var padresTutor = await _context.PadresTutor.FindAsync(id);

            if (padresTutor == null)
            {
                return NotFound();
            }

            return padresTutor;
        }

        // PUT: api/PadresTutors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPadresTutor(int id, PadresTutor padresTutor)
        {
            if (id != padresTutor.Cedula)
            {
                return BadRequest();
            }

            _context.Entry(padresTutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PadresTutorExists(id))
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

        // POST: api/PadresTutors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PadresTutor>> PostPadresTutor(PadresTutor padresTutor)
        {
            _context.PadresTutor.Add(padresTutor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PadresTutorExists(padresTutor.Cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPadresTutor", new { id = padresTutor.Cedula }, padresTutor);
        }

        // DELETE: api/PadresTutors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PadresTutor>> DeletePadresTutor(int id)
        {
            var padresTutor = await _context.PadresTutor.FindAsync(id);
            if (padresTutor == null)
            {
                return NotFound();
            }

            _context.PadresTutor.Remove(padresTutor);
            await _context.SaveChangesAsync();

            return padresTutor;
        }

        private bool PadresTutorExists(int id)
        {
            return _context.PadresTutor.Any(e => e.Cedula == id);
        }
    }
}
