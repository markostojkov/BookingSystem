using System;

namespace BookingSystem.Contracts
{
    public class ResourceResponse
    {
        public ResourceResponse(Guid uid, string name, int quantity)
        {
            Uid = uid;
            Name = name;
            Quantity = quantity;
        }

        public Guid Uid { get; }
        public string Name { get; }
        public int Quantity { get; }
    }
}
