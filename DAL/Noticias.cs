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
    public class Noticias : ICRUD<data.Noticias>
    {
        private RepositoryNoticias _repo = null;

        public Noticias(SolutionDbContext context)
        {
            _repo = new RepositoryNoticias(context);
        }
        public void Delete(data.Noticias t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Noticias> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Noticias>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsync();
        }

        public data.Noticias GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public data.Noticias GetOneByIdString(string id)
        {
            return _repo.GetOneByIdString(id);
        }

        public async Task<data.Noticias> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

        public void Insert(data.Noticias t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Noticias t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
