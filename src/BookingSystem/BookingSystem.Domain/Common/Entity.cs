using System;

namespace BookingSystem.Domain.Common
{
    public abstract class Entity
    {
        public Guid Uid { get; protected set; }
    }
}
