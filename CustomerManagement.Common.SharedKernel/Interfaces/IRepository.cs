using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Common.SharedKernel.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
