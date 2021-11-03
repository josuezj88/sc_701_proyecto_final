using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    interface IRepositoryProductos : IRepository<data.Productos>
    {
        Task<IEnumerable<data.Productos>> GetAllWithAsync();

        Task<data.Productos> GetOneByIdWithAsync(int id);
    }
}
