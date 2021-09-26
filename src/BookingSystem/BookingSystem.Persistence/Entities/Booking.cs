using System;

namespace BookingSystem.Persistence.Entities
{
    public class Booking : BaseEntity
    {
        public DateTime StartDate { get; protected set; }

        public DateTime EndDate { get; protected set; }

        public int BookedQuantity { get; protected set; }

        public long ResourceId { get; protected set; }

        public virtual Resource Resource { get; protected set; }

        protected Booking()
        {
        }

        public Booking(Guid uid, DateTime startDate, DateTime endDate, int bookedQuantity, long resourceFk) : base(uid)
        {
            StartDate = startDate;
            EndDate = endDate;
            BookedQuantity = bookedQuantity;
            ResourceId = resourceFk;
        }
    }
}
