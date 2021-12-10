using DAL.DO.Interface;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Condicion : ICRUD<data.Condicion>
    {
        private SolutionDbContext context;

        public Condicion(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Condicion t)
        {
            new DAL.Condicion(context).Delete(t);
        }

        public IEnumerable<data.Condicion> GetAll()
        {
            return new DAL.Condicion(context).GetAll();
        }

        public Task<IEnumerable<data.Condicion>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Condicion GetOneById(int id)
        {
            return new DAL.Condicion(context).GetOneById(id);
        }

        public data.Condicion GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public Task<data.Condicion> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Condicion t)
        {
            new DAL.Condicion(context).Insert(t);
        }

        public void Update(data.Condicion t)
        {
            new DAL.Condicion(context).Update(t);
        }
    }
}
