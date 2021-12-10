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
    public class TutoresController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public TutoresController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/Tutores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Tutores>>> GetTutores()
        {
            var res = new BS.Tutores(_context).GetAll().ToList();
            var mapaux = _mapper.Map<IEnumerable<data.Tutores>, IEnumerable<DataModels.Tutores>>(res).ToList();

            return mapaux;
        }

        // GET: api/Tutores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Tutores>> GetTutores(int id)
        {
            var Tutores = new BS.Tutores(_context).GetOneById(id);
            var mapaux = _mapper.Map<data.Tutores, DataModels.Tutores>(Tutores);

            if (Tutores == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Tutores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutores(int id, DataModels.Tutores Tutores)
        {
            if (id != Tutores.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Tutores, data.Tutores>(Tutores);
                new BS.Tutores(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!TutoresExists(id))
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

        // POST: api/Tutores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Tutores>> PostTutores(DataModels.Tutores Tutores)
        {
            var mapaux = _mapper.Map<DataModels.Tutores, data.Tutores>(Tutores);
            new BS.Tutores(_context).Insert(mapaux);

            return CreatedAtAction("GetTutores", new { id = Tutores.Id }, Tutores);
        }

        // DELETE: api/Tutores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Tutores>> DeleteTutores(int id)
        {
            var Tutores = new BS.Tutores(_context).GetOneById(id);

            if (Tutores == null)
            {
                return NotFound();
            }

            new BS.Tutores(_context).Delete(Tutores);
            var mapaux = _mapper.Map<data.Tutores, DataModels.Tutores>(Tutores);

            return mapaux;
        }

        private bool TutoresExists(int id)
        {
            return (new BS.Tutores(_context).GetOneById(id) != null);
        }
    }
}
