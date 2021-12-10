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
    public class DiariosQueryController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public DiariosQueryController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DiariosQuery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.AspNetUsers>>> GetTios()
        {
            var res = new BS.AspNetUsers(_context).Search(u => u.UserName.Equals("Usuario"));
            var mapaux = _mapper.Map<IEnumerable<data.AspNetUsers>, IEnumerable<DataModels.AspNetUsers>>(res).ToList();
            

            return mapaux;
        }

        // GET: api/DiariosQuery/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<DataModels.Diarios>>> GetDiario(string id)
        {
            var res = await new BS.Diarios(_context).GetLastByIdWithAsync(id);

            var mapaux = _mapper.Map<IEnumerable<data.Diarios>, IEnumerable<DataModels.Diarios>>(res).ToList();
            //mapping the different objects.

            return mapaux;
        }

        private bool AspNetUsersExists(string id)
        {
            return (new BS.AspNetUsers(_context).GetOneByIdString(id) != null);
        }
    }
}
