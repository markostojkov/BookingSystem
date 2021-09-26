using BookingSystem.Common.Mediator;
using BookingSystem.Common.Utils;
using BookingSystem.Contracts.Booking;
using BookingSystem.Persistence.Repositories.Interfaces;
using BookingSystem.Services.Booking.Mapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Services.Booking
{
    public class BookingService
    {
        public BookingService(IBookingRepo bookingRepo, IResourceRepo resourceRepo, IMediatorService mediatorService)
        {
            BookingRepo = bookingRepo;
            ResourceRepo = resourceRepo;
            MediatorService = mediatorService;
        }

        public IBookingRepo BookingRepo { get; }
        public IResourceRepo ResourceRepo { get; }
        public IMediatorService MediatorService { get; }

        public async Task<Result> BookResourceAsync(Guid resourceUid, BookResourceRequest request)
        {
            var domainBooking = Domain.Booking.Booking.Create(request.StartDate, request.EndDate, request.BookedQuantity);

            if (domainBooking.IsFailure)
            {
                return domainBooking;
            }

            var dbResourceWithBookingsInInterval =
                await ResourceRepo.GetResourcesWithBookingsInInterval(domainBooking.Value.IntervalValue.StartDate, domainBooking.Value.IntervalValue.EndDate, resourceUid);

            if (dbResourceWithBookingsInInterval.IsFailure)
            {
                return dbResourceWithBookingsInInterval;
            }

            var domainResource = dbResourceWithBookingsInInterval.Value.ToDomainResource();
            var domainExistingBookingsInInterval = dbResourceWithBookingsInInterval.Value.Bookings.ToDomainBookings();
            var booking = domainResource.Value.AddBookingToResource(domainBooking.Value, domainExistingBookingsInInterval.Select(x => x.Value));

            if (booking.IsFailure)
            {
                return booking;
            }

            await BookingRepo.Add(booking.Value.ToPersistenceBooking(dbResourceWithBookingsInInterval.Value.Id));
            await MediatorService.PublishEvents(domainResource.Value.DomainEvents);

            return Result.Ok();
        }
    }
}
