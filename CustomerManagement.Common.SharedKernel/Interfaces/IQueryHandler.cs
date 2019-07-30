using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Common.SharedKernel.Interfaces
{
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery
        where TResult : class
    {
        Task<TResult> HandleQueryAsync(TQuery Query, CancellationToken cancellationToken = default);
    }
}
