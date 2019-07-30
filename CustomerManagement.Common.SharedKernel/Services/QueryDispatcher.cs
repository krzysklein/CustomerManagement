using CustomerManagement.Common.SharedKernel.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Common.SharedKernel.Services
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> ExecuteQueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery
            where TResult : class
        {
            var handler = (IQueryHandler<TQuery, TResult>)_serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResult>));
            if (handler == null)
            {
                throw new Exception($"The Query Handler for type {typeof(TQuery).Name} returning {typeof(TResult).Name} is not registered!");
            }

            return await handler.HandleQueryAsync(query, cancellationToken);
        }
    }
}
