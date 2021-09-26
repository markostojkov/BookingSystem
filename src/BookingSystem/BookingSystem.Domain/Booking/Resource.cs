using BookingSystem.Common.Utils;
using BookingSystem.Domain.Booking.DomainEvents;
using BookingSystem.Domain.Booking.ValueObjects;
using BookingSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Domain.Booking
{
    public class Resource : AgregateRoot
    {
        public ResourceNameValue ResourceName { get; private set; }
        public ResourceQuantityValue ResourceQuantity { get; private set; }
        public IReadOnlyList<Booking> Bookings => _bookings;
        private readonly List<Booking> _bookings = new List<Booking>();

        private Resource(ResourceNameValue resourceName, ResourceQuantityValue resourceQuantity)
        {
            Uid = Guid.NewGuid();
            ResourceName = resourceName;
            ResourceQuantity = resourceQuantity;
        }

        private Resource(Guid uid, ResourceNameValue resourceName, ResourceQuantityValue resourceQuantity)
        {
            Uid = uid;
            Uid = Guid.NewGuid();
            ResourceName = resourceName;
            ResourceQuantity = resourceQuantity;
        }

        public static Result<Resource> Create(string name, int quantity)
        {
            var nameValue = ResourceNameValue.Create(name);
            var quantityValue = ResourceQuantityValue.Create(quantity);

            var successOrError = Result.FirstFailureOrOk(nameValue, quantityValue);

            if (successOrError.IsFailure)
            {
                return Result.FromError<Resource>(successOrError);
            }

            return Result.Ok(new Resource(nameValue.Value, quantityValue.Value));
        }

        public static Result<Resource> Create(Guid uid, string name, int quantity)
        {
            var nameValue = ResourceNameValue.Create(name);
            var quantityValue = ResourceQuantityValue.Create(quantity);

            var successOrError = Result.FirstFailureOrOk(nameValue, quantityValue);

            if (successOrError.IsFailure)
            {
                return Result.FromError<Resource>(successOrError);
            }

            return Result.Ok(new Resource(uid, nameValue.Value, quantityValue.Value));
        }

        public Result<Booking> AddBookingToResource(Booking booking, IEnumerable<Booking> existingBookings)
        {
            var bookingValue = booking.EntityInValidInterval(existingBookings, ResourceQuantity);

            if (bookingValue.IsFailure)
            {
                return Result.FromError<Booking>(bookingValue);
            }

            _bookings.AddRange(existingBookings);
            _bookings.Add(booking);

            _domainEvents.Add(new BookingCreated(Uid, booking.Uid));

            return Result.Ok(booking);
        }
    }
}
