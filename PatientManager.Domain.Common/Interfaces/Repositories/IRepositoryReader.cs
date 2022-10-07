using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace PatientManager.Domain.Common.Interfaces.Repositories
{
    public interface IRepositoryReader<TEntity> where TEntity : class, IAggregateRoot
    {
        Task<TEntity?> GetAsync(
            int? id = null,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Expression<Func<TEntity, TEntity>>? selector = null, bool tracking = false);

        Task<IEnumerable<TEntity>> GetAllAsync(
            int? page = null,
            int? pageSize = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Expression<Func<TEntity, TEntity>>? selector = null);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);
    }
}
