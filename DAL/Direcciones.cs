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
    public class Direcciones : ICRUD<data.Direcciones>
    {
        private Repository<data.Direcciones> _repo = null;

        public Direcciones(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Direcciones>(solutionDbContext);
        }

        public void Delete(data.Direcciones t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Direcciones> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Direcciones>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Direcciones GetOneById(int id)
        {
            return _repo.GetOneById(id);
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
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Direcciones t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
