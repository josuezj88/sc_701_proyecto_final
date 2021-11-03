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
    public class CondicionesController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public CondicionesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/Condicion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Condicion>>> GetCondicion()
        {
            var res = new BS.Condicion(_context).GetAll().ToList();
            var mapaux = _mapper.Map<IEnumerable<data.Condicion>, IEnumerable<DataModels.Condicion>>(res).ToList();

            return mapaux;
        }

        // GET: api/Condicion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Condicion>> GetCondicion(int id)
        {
            var Condicion = new BS.Condicion(_context).GetOneById(id);
            var mapaux = _mapper.Map<data.Condicion, DataModels.Condicion>(Condicion);

            if (Condicion == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Condicion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondicion(int id, DataModels.Condicion Condicion)
        {
            if (id != Condicion.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Condicion, data.Condicion>(Condicion);
                new BS.Condicion(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!CondicionExists(id))
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

        // POST: api/Condicion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Condicion>> PostCondicion(DataModels.Condicion Condicion)
        {
            var mapaux = _mapper.Map<DataModels.Condicion, data.Condicion>(Condicion);
            new BS.Condicion(_context).Insert(mapaux);

            return CreatedAtAction("GetCondicion", new { id = Condicion.Id }, Condicion);
        }

        // DELETE: api/Condicion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Condicion>> DeleteCondicion(int id)
        {
            var Condicion = new BS.Condicion(_context).GetOneById(id);

            if (Condicion == null)
            {
                return NotFound();
            }

            new BS.Condicion(_context).Delete(Condicion);
            var mapaux = _mapper.Map<data.Condicion, DataModels.Condicion>(Condicion);

            return mapaux;
        }

        private bool CondicionExists(int id)
        {
            return (new BS.Condicion(_context).GetOneById(id) != null);
        }
    }
}
