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
    public class ListaArticulosController : ControllerBase
    {
        private readonly PollitosContext _context;

        public ListaArticulosController(PollitosContext context)
        {
            _context = context;
        }

        // GET: api/ListaArticulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListaArticulos>>> GetListaArticulos()
        {
            return await _context.ListaArticulos.ToListAsync();
        }

        // GET: api/ListaArticulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaArticulos>> GetListaArticulos(int id)
        {
            var listaArticulos = await _context.ListaArticulos.FindAsync(id);

            if (listaArticulos == null)
            {
                return NotFound();
            }

            return listaArticulos;
        }

        // PUT: api/ListaArticulos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListaArticulos(int id, ListaArticulos listaArticulos)
        {
            if (id != listaArticulos.IdArticulo)
            {
                return BadRequest();
            }

            _context.Entry(listaArticulos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaArticulosExists(id))
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

        // POST: api/ListaArticulos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ListaArticulos>> PostListaArticulos(ListaArticulos listaArticulos)
        {
            _context.ListaArticulos.Add(listaArticulos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ListaArticulosExists(listaArticulos.IdArticulo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetListaArticulos", new { id = listaArticulos.IdArticulo }, listaArticulos);
        }

        // DELETE: api/ListaArticulos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ListaArticulos>> DeleteListaArticulos(int id)
        {
            var listaArticulos = await _context.ListaArticulos.FindAsync(id);
            if (listaArticulos == null)
            {
                return NotFound();
            }

            _context.ListaArticulos.Remove(listaArticulos);
            await _context.SaveChangesAsync();

            return listaArticulos;
        }

        private bool ListaArticulosExists(int id)
        {
            return _context.ListaArticulos.Any(e => e.IdArticulo == id);
        }
    }
}
