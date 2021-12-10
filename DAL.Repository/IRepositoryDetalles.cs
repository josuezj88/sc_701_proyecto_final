using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryDetalles : IRepository<data.Detalles>
    {
        Task<IEnumerable<data.Detalles>> GetAllWithAsync();

        Task<IEnumerable<data.Detalles>> GetAllWithAsyncById(int id);

        Task<data.Detalles> GetOneByIdWithAsync(int id);
    }
}
