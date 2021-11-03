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
    public class ProductosController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        private readonly IMapper _mapper;

        public ProductosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Productos>>> GetProductos()
        {
            var res = await new BS.Productos(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Productos>, IEnumerable<DataModels.Productos>>(res).ToList();

            return mapaux;
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Productos>> GetProductos(int id)
        {
            var Productos = await new BS.Productos(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Productos, DataModels.Productos>(Productos);

            if (Productos == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductos(int id, DataModels.Productos Productos)
        {
            if (id != Productos.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Productos, data.Productos>(Productos);
                new BS.Productos(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ProductosExists(id))
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
        public async Task<ActionResult<DataModels.Productos>> PostProductos(DataModels.Productos Productos)
        {
            var mapaux = _mapper.Map<DataModels.Productos, data.Productos>(Productos);
            new BS.Productos(_context).Insert(mapaux);

            return CreatedAtAction("GetProductos", new { id = Productos.Id }, Productos);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Productos>> DeleteProductos(int id)
        {
            var Productos = new BS.Productos(_context).GetOneById(id);

            if (Productos == null)
            {
                return NotFound();
            }

            new BS.Productos(_context).Delete(Productos);
            var mapaux = _mapper.Map<data.Productos, DataModels.Productos>(Productos);
            return mapaux;
        }

        private bool ProductosExists(int id)
        {
            return (new BS.Productos(_context).GetOneById(id) != null);
        }
    }
}
