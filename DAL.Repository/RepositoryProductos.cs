using DAL.DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public class RepositoryProductos : Repository<data.Productos>, IRepositoryProductos
    {
        public RepositoryProductos(SolutionDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Productos>> GetAllWithAsync()
        {
            return await dbContext.Productos.Include(m => m.Categoria).ToListAsync();
        }

        public async Task<Productos> GetOneByIdWithAsync(int id)
        {
            return await dbContext.Productos.Include(m => m.Categoria).SingleOrDefaultAsync(m => m.Id == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
