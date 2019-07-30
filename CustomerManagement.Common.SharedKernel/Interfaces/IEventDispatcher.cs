using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Common.SharedKernel.Interfaces
{
    public interface IEventDispatcher
    {
        Task PublishEventAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : IEvent;
        Task PublishEventsAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken = default);
    }
}
