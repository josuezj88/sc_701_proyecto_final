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
    public class RepositoryNoticias : Repository<data.Noticias>, IRepositoryNoticias
    {
        public RepositoryNoticias(SolutionDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Noticias>> GetAllWithAsync()
        {
            return await dbContext.Noticias.Include(m => m.ApplicationUser).ToListAsync();
        }

        public async Task<Noticias> GetOneByIdWithAsync(int id)
        {
            return await dbContext.Noticias.Include(m => m.ApplicationUser).SingleOrDefaultAsync(m => m.Id == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
