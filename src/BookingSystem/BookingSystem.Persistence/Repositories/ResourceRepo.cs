using BookingSystem.Common.Utils;
using BookingSystem.Persistence.DbContext;
using BookingSystem.Persistence.Entities;
using BookingSystem.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace BookingSystem.Persistence.Repositories
{
    public class ResourceRepo : Repository<Resource>, IResourceRepo
    {
        public ResourceRepo(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Resource>> GetResources()
        {
            return await DbSet.Include(x => x.Bookings).AsNoTracking().ToListAsync();
        }

        public async Task<Result<Resource>> GetResourcesWithBookingsInInterval(DateTime startDate, DateTime endDate, Guid resourceUid)
        {
            var dbResourceWithBookingsInInterval = await DbSet
                .IncludeFilter(x => x.Bookings.Where(y => startDate <= y.EndDate && endDate >= y.StartDate))
                .Where(x => x.Uid == resourceUid)
                .FirstOrDefaultAsync();

            if (dbResourceWithBookingsInInterval is null)
            {
                return Result.NotFound<Resource>(ResultErrorCodes.ResourceWithUidNotExist);
            }

            return Result.Ok(dbResourceWithBookingsInInterval);
        }
    }
}
