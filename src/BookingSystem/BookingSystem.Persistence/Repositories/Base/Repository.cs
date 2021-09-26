using BookingSystem.Persistence.DbContext;
using BookingSystem.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public Repository(AppDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected AppDbContext DbContext { get; }
        protected DbSet<T> DbSet { get; }

        public IQueryable<T> All()
        {
            return DbSet.AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await All().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task Add(T entity)
        {
            DbSet.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<T> GetByUidAsync(Guid uid)
        {
            return await All().FirstOrDefaultAsync(f => f.Uid == uid);
        }
    }
}
