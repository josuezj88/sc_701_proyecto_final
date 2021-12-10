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
    public class DiariosController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        private readonly IMapper _mapper;

        public DiariosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Diarios>>> GetDiarios()
        {
            var res = await new BS.Diarios(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Diarios>, IEnumerable<DataModels.Diarios>>(res).ToList();

            return mapaux;
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Diarios>> GetDiarios(int id)
        {
            var Diarios = await new BS.Diarios(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Diarios, DataModels.Diarios>(Diarios);

            if (Diarios == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiarios(int id, DataModels.Diarios Diarios)
        {
            if (id != Diarios.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Diarios, data.Diarios>(Diarios);
                new BS.Diarios(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!DiariosExists(id))
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
        public async Task<ActionResult<DataModels.Diarios>> PostDiarios(DataModels.Diarios Diarios)
        {
            var mapaux = _mapper.Map<DataModels.Diarios, data.Diarios>(Diarios);
            new BS.Diarios(_context).Insert(mapaux);

            return CreatedAtAction("GetDiarios", new { id = Diarios.Id }, Diarios);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Diarios>> DeleteDiarios(int id)
        {
            var Diarios = new BS.Diarios(_context).GetOneById(id);

            if (Diarios == null)
            {
                return NotFound();
            }

            new BS.Diarios(_context).Delete(Diarios);
            var mapaux = _mapper.Map<data.Diarios, DataModels.Diarios>(Diarios);
            return mapaux;
        }

        private bool DiariosExists(int id)
        {
            return (new BS.Diarios(_context).GetOneById(id) != null);
        }
    }
}
