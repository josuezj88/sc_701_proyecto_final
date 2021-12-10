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
    public class Categorias : ICRUD<data.Categorias>
    {
        private Repository<data.Categorias> _repo = null;

        public Categorias(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Categorias>(solutionDbContext);
        }
        public void Delete(data.Categorias t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Categorias> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Categorias>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Categorias GetOneById(int id)
        {
            return _repo.GetOneById(id);
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
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Categorias t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
