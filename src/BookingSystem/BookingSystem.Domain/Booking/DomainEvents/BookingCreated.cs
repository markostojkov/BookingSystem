using BookingSystem.Common.Mediator;
using System;

namespace BookingSystem.Domain.Booking.DomainEvents
{
    public class BookingCreated : IEvent
    {
        public BookingCreated(Guid resourceUid, Guid bookingUid)
        {
            ResourceUid = resourceUid;
            BookingUid = bookingUid;
        }

        public Guid ResourceUid { get; }
        public Guid BookingUid { get; }
    }
}
