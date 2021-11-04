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
    public class AspNetUsersController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public AspNetUsersController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/AspNetUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.AspNetUsers>>> GetAspNetUsers()
        {
            var res = new BS.AspNetUsers(_context).GetAll().ToList();
            var mapaux = _mapper.Map<IEnumerable<data.AspNetUsers>, IEnumerable<DataModels.AspNetUsers>>(res).ToList();

            return mapaux;
        }

        // GET: api/AspNetUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.AspNetUsers>> GetAspNetUser(string id)
        {
            var AspNetUsers = new BS.AspNetUsers(_context).GetOneByIdString(id);
            var mapaux = _mapper.Map<data.AspNetUsers, DataModels.AspNetUsers>(AspNetUsers);

            if (AspNetUsers == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/AspNetUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUsers(string id, DataModels.AspNetUsers AspNetUsers)
        {
            if (id != AspNetUsers.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.AspNetUsers, data.AspNetUsers>(AspNetUsers);
                new BS.AspNetUsers(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!AspNetUsersExists(id))
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

        // POST: api/AspNetUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.AspNetUsers>> PostAspNetUsers(DataModels.AspNetUsers AspNetUsers)
        {
            var mapaux = _mapper.Map<DataModels.AspNetUsers, data.AspNetUsers>(AspNetUsers);
            new BS.AspNetUsers(_context).Insert(mapaux);

            return CreatedAtAction("GetAspNetUsers", new { id = AspNetUsers.Id }, AspNetUsers);
        }

        // DELETE: api/AspNetUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.AspNetUsers>> DeleteAspNetUsers(string id)
        {
            var AspNetUsers = new BS.AspNetUsers(_context).GetOneByIdString(id);

            if (AspNetUsers == null)
            {
                return NotFound();
            }

            new BS.AspNetUsers(_context).Delete(AspNetUsers);
            var mapaux = _mapper.Map<data.AspNetUsers, DataModels.AspNetUsers>(AspNetUsers);

            return mapaux;
        }

        private bool AspNetUsersExists(string id)
        {
            return (new BS.AspNetUsers(_context).GetOneByIdString(id) != null);
        }
    }
}
