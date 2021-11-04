using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryDetalles : IRepository<data.Detalles>
    {
        Task<IEnumerable<data.Detalles>> GetAllWithAsync();

        Task<data.Detalles> GetOneByIdWithAsync(int id);
    }
}
