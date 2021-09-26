using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystem.Common.Mediator
{
    public interface IMediatorService
    {
        public Task PublishEvents(IEnumerable<IEvent> mediatorEvent);

        public Task PublishEvent(IEvent mediatorEvent);
    }
}
