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
    public class Detalles : ICRUD<data.Detalles>
    {
        private RepositoryDetalles _repo = null;

        public Detalles(SolutionDbContext context)
        {
            _repo = new RepositoryDetalles(context);
        }
        public void Delete(data.Detalles t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Detalles> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Detalles>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsync();
        }

        public data.Detalles GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public data.Detalles GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<data.Detalles> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

        public void Insert(data.Detalles t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Detalles t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
