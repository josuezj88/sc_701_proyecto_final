using DAL.DO.Interface;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Categorias : ICRUD<data.Categorias>
    {
        private SolutionDbContext context;

        public Categorias(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.Categorias t)
        {
            new DAL.Categorias(context).Delete(t);
        }

        public IEnumerable<data.Categorias> GetAll()
        {
            return new DAL.Categorias(context).GetAll();
        }

        public Task<IEnumerable<data.Categorias>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Categorias GetOneById(int id)
        {
            return new DAL.Categorias(context).GetOneById(id);
        }

        public data.Categorias GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public Task<data.Categorias> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Categorias t)
        {
            new DAL.Categorias(context).Insert(t);
        }

        public void Update(data.Categorias t)
        {
            new DAL.Categorias(context).Update(t);
        }
    }
}
