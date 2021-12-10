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
    public class Pollitos : ICRUD<data.Pollitos>
    {
        private RepositoryPollitos _repo = null;

        public Pollitos(SolutionDbContext context)
        {
            _repo = new RepositoryPollitos(context);
        }
        public void Delete(data.Pollitos t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Pollitos> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Pollitos>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsync();
        }

        public data.Pollitos GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public data.Pollitos GetOneByIdString(string id)
        {
            return _repo.GetOneByIdString(id);
        }

        public async Task<data.Pollitos> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

        public void Insert(data.Pollitos t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Pollitos t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
