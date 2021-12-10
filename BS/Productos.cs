using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.DO.Interface;
using DAL.EF;
using data = DAL.DO.Objects;

namespace BS
{
    public class Productos : ICRUD<data.Productos>
    {
        private SolutionDbContext _context;

        public Productos(SolutionDbContext context)
        {
            _context = context;
        }
        public void Delete(data.Productos t)
        {
            new DAL.Productos(_context).Delete(t);
        }

        public IEnumerable<data.Productos> GetAll()
        {
            return new DAL.Productos(_context).GetAll();
        }

        public async Task<IEnumerable<data.Productos>> GetAllWithAsync()
        {
            return await new DAL.Productos(_context).GetAllWithAsync();
        }

        public data.Productos GetOneById(int id)
        {
            return new DAL.Productos(_context).GetOneById(id);
        }

        public data.Productos GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<data.Productos> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Productos(_context).GetOneByIdWithAsync(id);
        }

        public void Insert(data.Productos t)
        {
            new DAL.Productos(_context).Insert(t);
        }

        public void Update(data.Productos t)
        {
            new DAL.Productos(_context).Update(t);
        }
    }
}
