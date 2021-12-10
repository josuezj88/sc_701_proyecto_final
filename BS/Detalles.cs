using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DO.Interface;
using DAL.EF;
using data = DAL.DO.Objects;

namespace BS
{
    public class Detalles : ICRUD<data.Detalles>, IDiario<data.Detalles>
    {
        private SolutionDbContext _context;

        public Detalles(SolutionDbContext context)
        {
            _context = context;
        }
        public void Delete(data.Detalles t)
        {
            new DAL.Detalles(_context).Delete(t);
        }

        public IEnumerable<data.Detalles> GetAll()
        {
            return new DAL.Detalles(_context).GetAll();
        }

        public async Task<IEnumerable<data.Detalles>> GetAllWithAsync()
        {
            return await new DAL.Detalles(_context).GetAllWithAsync();
        }

        public async Task<IEnumerable<data.Detalles>> GetAllWithAsyncById(int id)
        {
            return await new DAL.Detalles(_context).GetAllWithAsyncById(id);
        }

        public data.Detalles GetOneById(int id)
        {
            return new DAL.Detalles(_context).GetOneById(id);
        }

        public data.Detalles GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<data.Detalles> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Detalles(_context).GetOneByIdWithAsync(id);
        }

        public void Insert(data.Detalles t)
        {
            new DAL.Detalles(_context).Insert(t);
        }

        public void Update(data.Detalles t)
        {
            new DAL.Detalles(_context).Update(t);
        }
    }
}
