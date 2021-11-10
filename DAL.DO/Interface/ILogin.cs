using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.DO.Interface
{
    public interface ILogin<T>
    {
        T GetLoginByUser(string username, string password);

        T GetOne(Expression<Func<T, bool>> predicado);
    }
}
