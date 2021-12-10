using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.DO.Interface;
using DAL.EF;
using data = DAL.DO.Objects;

namespace BS
{
    public class Noticias : ICRUD<data.Noticias>
    {
        private SolutionDbContext _context;

        public Noticias(SolutionDbContext context)
        {
            _context = context;
        }
        public void Delete(data.Noticias t)
        {
            new DAL.Noticias(_context).Delete(t);
        }

        public IEnumerable<data.Noticias> GetAll()
        {
            return new DAL.Noticias(_context).GetAll();
        }

        public async Task<IEnumerable<data.Noticias>> GetAllWithAsync()
        {
            return await new DAL.Noticias(_context).GetAllWithAsync();
        }

        public data.Noticias GetOneById(int id)
        {
            return new DAL.Noticias(_context).GetOneById(id);
        }

        public data.Noticias GetOneByIdString(string id)
        {
            return new DAL.Noticias(_context).GetOneByIdString(id);
        }

        public async Task<data.Noticias> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Noticias(_context).GetOneByIdWithAsync(id);
        }

        public void Insert(data.Noticias t)
        {
            new DAL.Noticias(_context).Insert(t);
        }

        public void Update(data.Noticias t)
        {
            new DAL.Noticias(_context).Update(t);
        }
    }
}
