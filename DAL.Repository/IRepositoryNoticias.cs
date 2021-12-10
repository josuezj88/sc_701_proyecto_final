using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryNoticias : IRepository<data.Noticias>
    {
        Task<IEnumerable<data.Noticias>> GetAllWithAsync();

        Task<data.Noticias> GetOneByIdWithAsync(int id);
    }
}
