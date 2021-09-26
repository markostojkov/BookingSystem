using BookingSystem.Common.Mediator.Contracts;
using BookingSystem.Domain.Booking.DomainEvents;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookingSystem.Services.Booking.DomainEventHandlers
{
    public class SendEmailForBookedResource : IEventHandler<BookingCreated>
    {
        public SendEmailForBookedResource()
        {
        }

        // TODO: MOCK EMAIL I REGULAR
        public Task Handle(BookingCreated notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(string.Format("EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {0}", notification.BookingUid));
            return Task.CompletedTask;
        }
    }
}
