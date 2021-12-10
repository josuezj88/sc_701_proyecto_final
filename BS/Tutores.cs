using DAL.DO.Interface;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Tutores : ICRUD<data.Tutores>
    {
        private SolutionDbContext context;

        public Tutores(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Tutores t)
        {
            new DAL.Tutores(context).Delete(t);
        }

        public IEnumerable<data.Tutores> GetAll()
        {
            return new DAL.Tutores(context).GetAll();
        }

        public Task<IEnumerable<data.Tutores>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Tutores GetOneById(int id)
        {
            return new DAL.Tutores(context).GetOneById(id);
        }

        public data.Tutores GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public Task<data.Tutores> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Tutores t)
        {
            new DAL.Tutores(context).Insert(t);
        }

        public void Update(data.Tutores t)
        {
            new DAL.Tutores(context).Update(t);
        }
    }
}
