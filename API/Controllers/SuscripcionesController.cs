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
    public class SuscripcionesController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public SuscripcionesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Suscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IGrouping<DateTimeOffset?, DataModels.AspNetUsers>>>> GetSuscripciones()
        {
            var res = new BS.AspNetUsers(_context).GetSuscripciones();
            var mapaux = _mapper.Map<IEnumerable<data.AspNetUsers>, IEnumerable<DataModels.AspNetUsers>>(res).ToList();

            var grouped = mapaux.GroupBy(u => u.LockoutEnd).ToList();

            return grouped;
        }

        private bool AspNetUsersExists(string id)
        {
            return (new BS.AspNetUsers(_context).GetOneByIdString(id) != null);
        }
    }
}
