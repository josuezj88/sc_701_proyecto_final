using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.DO.Interface;
using DAL.EF;
using data = DAL.DO.Objects;

namespace BS
{
    public class Diarios : ICRUD<data.Diarios>
    {
        private SolutionDbContext _context;

        public Diarios(SolutionDbContext context)
        {
            _context = context;
        }
        public void Delete(data.Diarios t)
        {
            new DAL.Diarios(_context).Delete(t);
        }

        public IEnumerable<data.Diarios> GetAll()
        {
            return new DAL.Diarios(_context).GetAll();
        }

        public async Task<IEnumerable<data.Diarios>> GetAllWithAsync()
        {
            return await new DAL.Diarios(_context).GetAllWithAsync();
        }

        public data.Diarios GetOneById(int id)
        {
            return new DAL.Diarios(_context).GetOneById(id);
        }

        public data.Diarios GetOneByIdString(string id)
        {
            return new DAL.Diarios(_context).GetOneByIdString(id);
        }

        public async Task<data.Diarios> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Diarios(_context).GetOneByIdWithAsync(id);
        }

        public void Insert(data.Diarios t)
        {
            new DAL.Diarios(_context).Insert(t);
        }

        public void Update(data.Diarios t)
        {
            new DAL.Diarios(_context).Update(t);
        }
    }
}
