using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryPollitos : IRepository<data.Pollitos>
    {
        Task<IEnumerable<data.Pollitos>> GetAllWithAsync();

        Task<data.Pollitos> GetOneByIdWithAsync(int id);
    }
}
