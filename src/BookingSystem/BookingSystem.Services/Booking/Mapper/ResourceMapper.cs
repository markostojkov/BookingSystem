using BookingSystem.Common.Utils;
using BookingSystem.Contracts;
using BookingSystem.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Services.Booking.Mapper
{
    public static class ResourceMapper
    {
        public static List<ResourceResponse> ToResourceResponse(this IEnumerable<Resource> resources)
        {
            return resources.Select(x => new ResourceResponse(x.Uid, x.Name, x.Quantity)).ToList();
        }

        public static Result<Domain.Booking.Resource> ToDomainResource(this Resource resource)
        {
            return Domain.Booking.Resource.Create(resource.Uid, resource.Name, resource.Quantity);
        }
    }
}
