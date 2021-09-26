using System;
using System.Collections.Generic;

namespace BookingSystem.Persistence.Entities
{
    public class Resource : BaseEntity
    {
        public string Name { get; protected set; }

        public int Quantity { get; protected set; }

        public virtual ICollection<Booking> Bookings { get; protected set; }

        protected Resource()
        {
        }

        public Resource(Guid uid, string name, int quantity, ICollection<Booking> bookings) : base(uid)
        {
            Name = name;
            Quantity = quantity;
            Bookings = bookings;
        }

        // ONLY FOR SEEDING
        public Resource(long id, Guid uid, string name, int quantity, ICollection<Booking> bookings) : base(uid)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Bookings = bookings;
        }
    }
}
