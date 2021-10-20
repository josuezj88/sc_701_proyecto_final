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
    public class InfoUsuariosController : ControllerBase
    {
        private readonly PollitosContext _context;

        public InfoUsuariosController(PollitosContext context)
        {
            _context = context;
        }

        // GET: api/InfoUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoUsuario>>> GetInfoUsuario()
        {
            return await _context.InfoUsuario.ToListAsync();
        }

        // GET: api/InfoUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoUsuario>> GetInfoUsuario(int id)
        {
            var infoUsuario = await _context.InfoUsuario.FindAsync(id);

            if (infoUsuario == null)
            {
                return NotFound();
            }

            return infoUsuario;
        }

        // PUT: api/InfoUsuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoUsuario(int id, InfoUsuario infoUsuario)
        {
            if (id != infoUsuario.CedulaU)
            {
                return BadRequest();
            }

            _context.Entry(infoUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoUsuarioExists(id))
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

        // POST: api/InfoUsuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InfoUsuario>> PostInfoUsuario(InfoUsuario infoUsuario)
        {
            _context.InfoUsuario.Add(infoUsuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InfoUsuarioExists(infoUsuario.CedulaU))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInfoUsuario", new { id = infoUsuario.CedulaU }, infoUsuario);
        }

        // DELETE: api/InfoUsuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InfoUsuario>> DeleteInfoUsuario(int id)
        {
            var infoUsuario = await _context.InfoUsuario.FindAsync(id);
            if (infoUsuario == null)
            {
                return NotFound();
            }

            _context.InfoUsuario.Remove(infoUsuario);
            await _context.SaveChangesAsync();

            return infoUsuario;
        }

        private bool InfoUsuarioExists(int id)
        {
            return _context.InfoUsuario.Any(e => e.CedulaU == id);
        }
    }
}
