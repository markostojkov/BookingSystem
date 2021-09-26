using System;

namespace BookingSystem.Contracts.Booking
{
    public class BookResourceRequest
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int BookedQuantity { get; set; }
    }
}
