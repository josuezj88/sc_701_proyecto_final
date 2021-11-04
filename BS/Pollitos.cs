using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.DO.Interface;
using DAL.EF;
using data = DAL.DO.Objects;

namespace BS
{
    public class Pollitos : ICRUD<data.Pollitos>
    {
        private SolutionDbContext _context;

        public Pollitos(SolutionDbContext context)
        {
            _context = context;
        }
        public void Delete(data.Pollitos t)
        {
            new DAL.Pollitos(_context).Delete(t);
        }

        public IEnumerable<data.Pollitos> GetAll()
        {
            return new DAL.Pollitos(_context).GetAll();
        }

        public async Task<IEnumerable<data.Pollitos>> GetAllWithAsync()
        {
            return await new DAL.Pollitos(_context).GetAllWithAsync();
        }

        public data.Pollitos GetOneById(int id)
        {
            return new DAL.Pollitos(_context).GetOneById(id);
        }

        public data.Pollitos GetOneByIdString(string id)
        {
            return new DAL.Pollitos(_context).GetOneByIdString(id);
        }

        public async Task<data.Pollitos> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Pollitos(_context).GetOneByIdWithAsync(id);
        }

        public void Insert(data.Pollitos t)
        {
            new DAL.Pollitos(_context).Insert(t);
        }

        public void Update(data.Pollitos t)
        {
            new DAL.Pollitos(_context).Update(t);
        }
    }
}
