using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Common.SharedKernel.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<TResult> ExecuteQueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery
            where TResult : class;
    }
}
