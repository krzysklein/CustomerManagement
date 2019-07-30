using CustomerManagement.Common.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace CustomerManagement.Common.SharedKernel
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IEvent> _events;
        protected IReadOnlyList<IEvent> Events => _events;

        protected AggregateRoot(bool newId = false)
            : base(newId)
        {
            _events = new List<IEvent>();
        }

        protected void ApplyEvent(IEvent @event)
        {
            _events.Add(@event);
        }
    }

}
