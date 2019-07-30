using CustomerManagement.Common.SharedKernel.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Common.SharedKernel.Services
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SendCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) 
            where TCommand : ICommand
        {
            var handler = (ICommandHandler<TCommand>)_serviceProvider.GetService(typeof(ICommandHandler<TCommand>));
            if (handler == null)
            {
                throw new Exception($"The Command Handler for type {typeof(TCommand).Name} is not registered!");
            }

            await handler.HandleCommandAsync(command, cancellationToken);
        }
    }
}
