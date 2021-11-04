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
    public class RepositoryDetalles : Repository<data.Detalles>, IRepositoryDetalles
    {
        public RepositoryDetalles(SolutionDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Detalles>> GetAllWithAsync()
        {
            return await dbContext.Detalles.Include(m => m.Productos).ToListAsync();
        }

        public async Task<Detalles> GetOneByIdWithAsync(int id)
        {
            return await dbContext.Detalles.Include(m => m.Productos).SingleOrDefaultAsync(m => m.IdDiario == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
