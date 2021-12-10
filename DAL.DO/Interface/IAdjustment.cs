using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DO.Interface
{
    public interface IAdjustment<T>
    {
        Task<IEnumerable<T>> GetLastByIdWithAsync(string id);

        IEnumerable<T> Search(Expression<Func<T, bool>> predicado);
    }
}
