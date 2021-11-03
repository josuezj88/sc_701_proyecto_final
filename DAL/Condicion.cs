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
    public class Condicion : ICRUD<data.Condicion>
    {
        private Repository<data.Condicion> _repo = null;

        public Condicion(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Condicion>(solutionDbContext);
        }

        public void Delete(data.Condicion t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Condicion> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Condicion>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Condicion GetOneById(int id)
        {
            return _repo.GetOneById(id);
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
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Condicion t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
