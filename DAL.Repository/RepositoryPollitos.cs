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
    public class RepositoryPollitos : Repository<data.Pollitos>, IRepositoryPollitos
    {
        public RepositoryPollitos(SolutionDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Pollitos>> GetAllWithAsync()
        {
            return await dbContext.Pollitos.Include(m => m.ApplicationUser).Include(m => m.Condicion).Include(m => m.Direccion).Include(m => m.Tutor).ToListAsync();
        }

        public async Task<Pollitos> GetOneByIdWithAsync(int id)
        {
            return await dbContext.Pollitos.Include(m => m.ApplicationUser).Include(m => m.Condicion).Include(m => m.Direccion).Include(m => m.Tutor).SingleOrDefaultAsync(m => m.Id == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
