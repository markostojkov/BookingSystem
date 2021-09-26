using BookingSystem.Domain.Common.ValueObjects;
using BookingSystem.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories.Interfaces
{
    public interface IBookingRepo : IRepository<Booking>
    {
        public Task<List<Booking>> GetBookingsInInterval(IntervalValue intervalValue, Guid resourceUid);
    }
}
