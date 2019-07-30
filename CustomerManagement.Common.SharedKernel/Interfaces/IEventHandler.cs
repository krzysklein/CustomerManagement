using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Common.SharedKernel.Interfaces
{
    public interface IEventHandler<in TEvent>
        where TEvent : IEvent
    {
        Task HandleEventAsync(TEvent @event, CancellationToken cancellationToken = default);
    }
}
