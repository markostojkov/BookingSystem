using BookingSystem.Common.Utils;
using BookingSystem.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories.Interfaces
{
    public interface IResourceRepo : IRepository<Resource>
    {
        public Task<List<Resource>> GetResources();

        public Task<Result<Resource>> GetResourcesWithBookingsInInterval(DateTime startDate, DateTime endDate, Guid resourceUid);
    }
}
