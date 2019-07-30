using CustomerManagement.Common.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Common.SharedKernel.Services
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventDispatcher(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task PublishEventAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            var handlers = (IEnumerable<IEventHandler<TEvent>>)_serviceProvider.GetService(typeof(IEnumerable<IEventHandler<TEvent>>));
            if ((handlers != null) && (handlers.Any()))
            {
                var handlerTasks = handlers.Select(handler => handler.HandleEventAsync(@event, cancellationToken));
                await Task.WhenAll(handlerTasks);
            }
        }

        public async Task PublishEventsAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken = default)
        {
            if ((events != null) && (events.Any()))
            {
                foreach (dynamic @event in events)
                {
                    await PublishEventAsync(@event, cancellationToken);
                }
            }
        }
    }
}
