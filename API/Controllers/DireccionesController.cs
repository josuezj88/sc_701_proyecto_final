using AutoMapper;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionesController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public DireccionesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/Direcciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Direcciones>>> GetDirecciones()
        {
            var res = new BS.Direcciones(_context).GetAll().ToList();
            var mapaux = _mapper.Map<IEnumerable<data.Direcciones>, IEnumerable<DataModels.Direcciones>>(res).ToList();

            return mapaux;
        }

        // GET: api/Direcciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Direcciones>> GetDirecciones(int id)
        {
            var Direcciones = new BS.Direcciones(_context).GetOneById(id);
            var mapaux = _mapper.Map<data.Direcciones, DataModels.Direcciones>(Direcciones);

            if (Direcciones == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Direcciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirecciones(int id, DataModels.Direcciones Direcciones)
        {
            if (id != Direcciones.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Direcciones, data.Direcciones>(Direcciones);
                new BS.Direcciones(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!DireccionesExists(id))
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

        // POST: api/Direcciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Direcciones>> PostDirecciones(DataModels.Direcciones Direcciones)
        {
            var mapaux = _mapper.Map<DataModels.Direcciones, data.Direcciones>(Direcciones);
            new BS.Direcciones(_context).Insert(mapaux);

            return CreatedAtAction("GetDirecciones", new { id = Direcciones.Id }, Direcciones);
        }

        // DELETE: api/Direcciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Direcciones>> DeleteDirecciones(int id)
        {
            var Direcciones = new BS.Direcciones(_context).GetOneById(id);

            if (Direcciones == null)
            {
                return NotFound();
            }

            new BS.Direcciones(_context).Delete(Direcciones);
            var mapaux = _mapper.Map<data.Direcciones, DataModels.Direcciones>(Direcciones);

            return mapaux;
        }

        private bool DireccionesExists(int id)
        {
            return (new BS.Direcciones(_context).GetOneById(id) != null);
        }
    }
}
