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
    public class PollitosController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        private readonly IMapper _mapper;

        public PollitosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Pollitos>>> GetPollitos()
        {
            var res = await new BS.Pollitos(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Pollitos>, IEnumerable<DataModels.Pollitos>>(res).ToList();

            return mapaux;
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Pollitos>> GetPollitos(int id)
        {
            var Pollitos = await new BS.Pollitos(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Pollitos, DataModels.Pollitos>(Pollitos);

            if (Pollitos == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPollitos(int id, DataModels.Pollitos Pollitos)
        {
            if (id != Pollitos.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Pollitos, data.Pollitos>(Pollitos);
                new BS.Pollitos(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!PollitosExists(id))
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
        public async Task<ActionResult<DataModels.Pollitos>> PostPollitos(DataModels.Pollitos Pollitos)
        {
            var mapaux = _mapper.Map<DataModels.Pollitos, data.Pollitos>(Pollitos);
            new BS.Pollitos(_context).Insert(mapaux);

            return CreatedAtAction("GetPollitos", new { id = Pollitos.Id }, Pollitos);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Pollitos>> DeletePollitos(int id)
        {
            var Pollitos = new BS.Pollitos(_context).GetOneById(id);

            if (Pollitos == null)
            {
                return NotFound();
            }

            new BS.Pollitos(_context).Delete(Pollitos);
            var mapaux = _mapper.Map<data.Pollitos, DataModels.Pollitos>(Pollitos);
            return mapaux;
        }

        private bool PollitosExists(int id)
        {
            return (new BS.Pollitos(_context).GetOneById(id) != null);
        }
    }
}
