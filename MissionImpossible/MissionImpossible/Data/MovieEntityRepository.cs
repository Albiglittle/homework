using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MissionImpossible.Models;

namespace MissionImpossible.Data
{
    internal class EfRepository<T> : IRepository<T> where T : MovieEntity
    {
        protected DbSet<T> Data;
        protected MovieDbContext DbCtx;
        public EfRepository(DbSet<T> dbSet, MovieDbContext ctx)
        {
            Data = dbSet;
            DbCtx = ctx;
        }

        public IQueryable<T> GetAll()
        {
            return Data;
        }

        public Task<T[]> ToArrayAsync(IQueryable<T> query)
        {
            return query.ToArrayAsync();
        }

        public Task<List<T>> ToListAsync(IQueryable<T> query)
        {
            return query.ToListAsync();
        }

        public async Task Save(T entity)
        {
            if (await Data.Where(x => x.Id == entity.Id).FirstOrDefaultAsync() == null)
            {
                Data.Add(entity);
            }
            await DbCtx.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            Data.Remove(entity);
            await DbCtx.SaveChangesAsync();
        }

        public async Task Wipe()
        {
            Data.RemoveRange(Data);
            await DbCtx.SaveChangesAsync();
        }
    }
}