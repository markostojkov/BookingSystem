using BookingSystem.Common.Utils;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Services.Booking.Mapper
{
    public static class BookingMapper
    {
        public static List<Result<Domain.Booking.Booking>> ToDomainBookings(this IEnumerable<Persistence.Entities.Booking> bookings)
        {
            return bookings.Select(x => Domain.Booking.Booking.Create(x.Uid, x.StartDate, x.EndDate, x.BookedQuantity)).ToList();
        }

        public static Persistence.Entities.Booking ToPersistenceBooking(this Domain.Booking.Booking booking, long resourceFk)
        {
            return new Persistence.Entities.Booking(booking.Uid, booking.IntervalValue.StartDate, booking.IntervalValue.EndDate, booking.BookingQuantity.Quantity, resourceFk);
        }
    }
}
