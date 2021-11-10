using DAL.DO.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using DAL.Repository;
using DAL.EF;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DAL
{
    public class AspNetUsers : ICRUD<data.AspNetUsers>, ILogin<data.AspNetUsers>
    {
        private Repository<data.AspNetUsers> _repo = null;

        public AspNetUsers(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.AspNetUsers>(solutionDbContext);
        }
        public void Delete(data.AspNetUsers t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.AspNetUsers> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.AspNetUsers>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.AspNetUsers GetLoginByUser(string username, string password)
        {
            return _repo.GetLoginByUser(username, password);
        }

        public data.AspNetUsers GetOne(Expression<Func<data.AspNetUsers, bool>> predicado)
        {
            return _repo.GetOne(predicado);
        }

        public data.AspNetUsers GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public data.AspNetUsers GetOneByIdString(string id)
        {
            return _repo.GetOneByIdString(id);
        }



        public Task<data.AspNetUsers> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.AspNetUsers t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.AspNetUsers t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
