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
    public class Diarios : ICRUD<data.Diarios>
    {
        private RepositoryDiario _repo = null;

        public Diarios(SolutionDbContext context)
        {
            _repo = new RepositoryDiario(context);
        }

        public void Delete(data.Diarios t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Diarios> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Diarios>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsync();
        }

        public data.Diarios GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public data.Diarios GetOneByIdString(string id)
        {
            return _repo.GetOneByIdString(id);
        }

        public async Task<data.Diarios> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

        public void Insert(data.Diarios t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Diarios t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
