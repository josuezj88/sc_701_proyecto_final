using DAL.DO.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using DAL.Repository;
using DAL.EF;
using System.Threading.Tasks;

namespace DAL
{
    public class Tutores : ICRUD<data.Tutores>
    {
        private Repository<data.Tutores> _repo = null;

        public Tutores(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Tutores>(solutionDbContext);
        }
        public void Delete(data.Tutores t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Tutores> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Tutores>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Tutores GetOneById(int id)
        {
            return _repo.GetOneById(id);
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
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Tutores t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
