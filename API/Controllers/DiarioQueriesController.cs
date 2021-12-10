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
    public class DiarioQueriesController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public DiarioQueriesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DiarioQueries/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<DataModels.Detalles>>> GetDetalles(int id)
        {
            var res = await new BS.Detalles(_context).GetAllWithAsyncById(id);

            var mapaux = _mapper.Map<IEnumerable<data.Detalles>, IEnumerable<DataModels.Detalles>>(res).ToList();
            //mapping the different objects.

            return mapaux;
        }

        private bool AspNetUsersExists(string id)
        {
            return (new BS.AspNetUsers(_context).GetOneByIdString(id) != null);
        }
    }
}
