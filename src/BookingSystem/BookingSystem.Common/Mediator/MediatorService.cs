using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystem.Common.Mediator
{
    public class MediatorService : IMediatorService
    {
        public MediatorService(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }

        public async Task PublishEvent(IEvent mediatorEvent)
        {
            await Mediator.Publish(mediatorEvent);
        }

        public async Task PublishEvents(IEnumerable<IEvent> mediatorEvent)
        {
            foreach (var item in mediatorEvent)
            {
                await PublishEvent(item);
            }
        }
    }
}
