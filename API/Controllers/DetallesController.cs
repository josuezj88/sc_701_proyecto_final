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
    public class DetallesController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        private readonly IMapper _mapper;

        public DetallesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Detalles>>> GetDetalles()
        {
            var res = await new BS.Detalles(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Detalles>, IEnumerable<DataModels.Detalles>>(res).ToList();
            //mapping the different objects.

            return mapaux;
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Detalles>> GetDetalles(int id)
        {
            var Detalles = await new BS.Detalles(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Detalles, DataModels.Detalles>(Detalles);

            if (Detalles == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalles(int id, DataModels.Detalles Detalles)
        {
            if (id != Detalles.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Detalles, data.Detalles>(Detalles);
                new BS.Detalles(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!DetallesExists(id))
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

        // POST: api/Activities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Detalles>> PostDetalles(DataModels.Detalles Detalles)
        {
            var mapaux = _mapper.Map<DataModels.Detalles, data.Detalles>(Detalles);
            new BS.Detalles(_context).Insert(mapaux);

            return CreatedAtAction("GetDetalles", new { id = Detalles.Id }, Detalles);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Detalles>> DeleteDetalles(int id)
        {
            var Detalles = new BS.Detalles(_context).GetOneById(id);

            if (Detalles == null)
            {
                return NotFound();
            }

            new BS.Detalles(_context).Delete(Detalles);
            var mapaux = _mapper.Map<data.Detalles, DataModels.Detalles>(Detalles);
            return mapaux;
        }

        private bool DetallesExists(int id)
        {
            return (new BS.Detalles(_context).GetOneById(id) != null);
        }
    }
}
