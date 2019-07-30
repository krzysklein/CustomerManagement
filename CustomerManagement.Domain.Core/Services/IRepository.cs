using CustomerManagement.Common.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Core.Services
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        Task SaveChanges(CancellationToken cancellationToken = default);
    }
}
