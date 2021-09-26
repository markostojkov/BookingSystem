using BookingSystem.Common.Utils;
using BookingSystem.Contracts;
using BookingSystem.Persistence.Repositories.Interfaces;
using BookingSystem.Services.Booking.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystem.Services.Booking
{
    public class ResourceService
    {
        public ResourceService(IResourceRepo resourceRepo)
        {
            ResourceRepo = resourceRepo;
        }

        public IResourceRepo ResourceRepo { get; }

        public async Task<Result<List<ResourceResponse>>> GetResourcesAsync()
        {
            var dbResources = await ResourceRepo.GetResources();
            return Result.Ok(dbResources.ToResourceResponse());
        }
    }
}
