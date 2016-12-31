using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionImpossible.Data
{
    public interface IRepository<T> 
    {
        IQueryable<T> GetAll();
        Task<T[]> ToArrayAsync(IQueryable<T> query);
        Task<List<T> > ToListAsync(IQueryable<T> query);
        Task Save(T entity);
        Task Delete(T entity);
        Task Wipe();
    }
}
