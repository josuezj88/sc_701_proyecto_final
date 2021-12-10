using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.DO.Interface;
using DAL.EF;
using DAL.Repository;
using data = DAL.DO.Objects;

namespace DAL
{
    public class Productos : ICRUD<data.Productos>
    {
        private RepositoryProductos _repo = null;

        public Productos(SolutionDbContext context)
        {
            _repo = new RepositoryProductos(context);
        }

        public void Delete(data.Productos t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Productos> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Productos>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsync();
        }

        public data.Productos GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public data.Productos GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<data.Productos> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

        public void Insert(data.Productos t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Productos t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
