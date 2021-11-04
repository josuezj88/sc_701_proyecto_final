using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.DO.Interface;
using DAL.EF;
using data = DAL.DO.Objects;

namespace BS
{
    public class AspNetUsers : ICRUD<data.AspNetUsers>
    {
        private SolutionDbContext _context;

        public AspNetUsers(SolutionDbContext context)
        {
            _context = context;
        }
        public void Delete(data.AspNetUsers t)
        {
            new DAL.AspNetUsers(_context).Delete(t);
        }

        public IEnumerable<data.AspNetUsers> GetAll()
        {
            return new DAL.AspNetUsers(_context).GetAll();
        }

        public Task<IEnumerable<data.AspNetUsers>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.AspNetUsers GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public data.AspNetUsers GetOneByIdString(string id)
        {
            return new DAL.AspNetUsers(_context).GetOneByIdString(id);
        }

        public Task<data.AspNetUsers> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.AspNetUsers t)
        {
            new DAL.AspNetUsers(_context).Insert(t);
        }

        public void Update(data.AspNetUsers t)
        {
            new DAL.AspNetUsers(_context).Update(t);
        }
    }
}
