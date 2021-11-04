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
    public class RepositoryDiario : Repository<data.Diarios>, IRepositoryDiario
    {
        public RepositoryDiario(SolutionDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Diarios>> GetAllWithAsync()
        {
            return await dbContext.Diarios.Include(m => m.ApplicationUser).Include(m => m.Detalle).Include(m => m.Pollito).ToListAsync();
        }

        public async Task<Diarios> GetOneByIdWithAsync(int id)
        {
            return await dbContext.Diarios.Include(m => m.ApplicationUser).Include(m => m.Detalle).Include(m => m.Pollito).SingleOrDefaultAsync(m => m.Id == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
