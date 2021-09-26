using MediatR;

namespace BookingSystem.Common.Mediator.Contracts
{
    public interface IEventHandler<T> : INotificationHandler<T> where T : IEvent
    {
    }
}
