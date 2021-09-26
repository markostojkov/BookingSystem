using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        Task<T> GetByUidAsync(Guid uid);

        Task<T> GetByIdAsync(int id);

        Task Add(T entity);
    }
}
