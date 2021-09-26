using BookingSystem.Domain.Common.ValueObjects;
using BookingSystem.Persistence.DbContext;
using BookingSystem.Persistence.Entities;
using BookingSystem.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class BookingRepo : Repository<Booking>, IBookingRepo
    {
        public BookingRepo(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Booking>> GetBookingsInInterval(IntervalValue intervalValue, Guid resourceUid)
        {
            return await DbSet
                .Include(x => x.Resource)
                .Where(x => intervalValue.StartDate < x.EndDate && intervalValue.EndDate > x.StartDate)
                .Where(x => x.Resource.Uid == resourceUid)
                .ToListAsync();
        }
    }
}
