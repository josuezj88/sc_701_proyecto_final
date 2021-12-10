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
    public class NoticiasController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        private readonly IMapper _mapper;

        public NoticiasController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Noticias>>> GetNoticias()
        {
            var res = await new BS.Noticias(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Noticias>, IEnumerable<DataModels.Noticias>>(res).ToList();

            return mapaux;
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Noticias>> GetNoticias(int id)
        {
            var Noticias = await new BS.Noticias(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Noticias, DataModels.Noticias>(Noticias);

            if (Noticias == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoticias(int id, DataModels.Noticias Noticias)
        {
            if (id != Noticias.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Noticias, data.Noticias>(Noticias);
                new BS.Noticias(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!NoticiasExists(id))
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
        public async Task<ActionResult<DataModels.Noticias>> PostNoticias(DataModels.Noticias Noticias)
        {
            var mapaux = _mapper.Map<DataModels.Noticias, data.Noticias>(Noticias);
            new BS.Noticias(_context).Insert(mapaux);

            return CreatedAtAction("GetNoticias", new { id = Noticias.Id }, Noticias);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Noticias>> DeleteNoticias(int id)
        {
            var Noticias = new BS.Noticias(_context).GetOneById(id);

            if (Noticias == null)
            {
                return NotFound();
            }

            new BS.Noticias(_context).Delete(Noticias);
            var mapaux = _mapper.Map<data.Noticias, DataModels.Noticias>(Noticias);
            return mapaux;
        }

        private bool NoticiasExists(int id)
        {
            return (new BS.Noticias(_context).GetOneById(id) != null);
        }
    }
}
