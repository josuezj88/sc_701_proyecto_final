using DAL.DO.Interface;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Direcciones : ICRUD<data.Direcciones>
    {
        private SolutionDbContext context;

        public Direcciones(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Direcciones t)
        {
            new DAL.Direcciones(context).Delete(t);
        }

        public IEnumerable<data.Direcciones> GetAll()
        {
            return new DAL.Direcciones(context).GetAll();
        }

        public Task<IEnumerable<data.Direcciones>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Direcciones GetOneById(int id)
        {
            return new DAL.Direcciones(context).GetOneById(id);
        }

        public data.Direcciones GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public Task<data.Direcciones> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Direcciones t)
        {
            new DAL.Direcciones(context).Insert(t);
        }

        public void Update(data.Direcciones t)
        {
            new DAL.Direcciones(context).Update(t);
        }
    }
}
