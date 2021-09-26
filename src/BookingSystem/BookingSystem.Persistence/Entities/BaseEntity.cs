using System;

namespace BookingSystem.Persistence.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; protected set; }

        public Guid Uid { get; protected set; }

        protected BaseEntity()
        {
        }

        protected BaseEntity(Guid uid)
        {
            Uid = uid;
        }
    }
}
