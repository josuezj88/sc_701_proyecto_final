using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryDiario : IRepository<data.Diarios>
    {
        Task<IEnumerable<data.Diarios>> GetAllWithAsync();

        Task<data.Diarios> GetOneByIdWithAsync(int id);

        Task<IEnumerable<data.Diarios>> GetLastByIdWithAsync(string id);

    }
}
