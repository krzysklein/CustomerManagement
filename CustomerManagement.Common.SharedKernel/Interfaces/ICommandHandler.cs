using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Common.SharedKernel.Interfaces
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task HandleCommandAsync(TCommand command, CancellationToken cancellationToken = default);
    }
}
