using DAL.DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public class RepositoryDetalles : Repository<data.Detalles>, IRepositoryDetalles
    {
        public RepositoryDetalles(SolutionDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Detalles>> GetAllWithAsync()
        {
            return await dbContext.Detalles.Include(m => m.Productos).Include(m => m.Diario).ToListAsync();
            
        }

        public async Task<Detalles> GetOneByIdWithAsync(int id)
        {
            return await dbContext.Detalles.Include(m => m.Productos).Include(m => m.Diario).SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Detalles>> GetAllWithAsyncById(int id)
        {
            
            return await dbContext.Detalles.Include(m => m.Productos).Include(m => m.Diario).Where(m => m.DiarioId == id).ToListAsync();

        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
