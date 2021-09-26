using BookingSystem.Common.Mediator;
using System.Collections.Generic;

namespace BookingSystem.Domain.Common
{
    public abstract class AgregateRoot : Entity
    {
        public IReadOnlyList<IEvent> DomainEvents => _domainEvents;
        protected readonly List<IEvent> _domainEvents = new List<IEvent>();
    }
}
