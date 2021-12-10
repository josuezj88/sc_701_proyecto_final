using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repository
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> AsQueryable();

        IEnumerable<T> GetAll();

        IEnumerable<T> GetSuscripciones();

        IEnumerable<T> Search(Expression<Func<T, bool>> predicado);

        T GetOne(Expression<Func<T, bool>> predicado);

        T GetOneById(int id);

        T GetOneByIdString(string id);

        T GetLoginByUser(string username, string password);

        void Insert(T t);

        void Update(T t);
        void Delete(T t);

        void Commit();

        void AddRange(IEnumerable<T> t);

        void UpdateRange(IEnumerable<T> t);

        void RemoveRange(IEnumerable<T> t);
    }
}
