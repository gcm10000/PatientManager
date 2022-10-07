using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PatientManager.Domain.Common.Entities;
using PatientManager.Domain.Common.Interfaces;
using PatientManager.Domain.Common.Interfaces.Repositories;
using PatientManager.Sql.DbContexts;
using PatientManager.Sql.Extensions;
using System.Linq.Expressions;

namespace PatientManager.Sql.Repositories
{
    public abstract class RepositoryBase<TEntity>
        : IRepositoryReader<TEntity>, IRepositoryWriter<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly DataContext _coreDbContext;

        public RepositoryBase(DataContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
            DbSet = coreDbContext.Set<TEntity>();
        }

        #region Reader Methods

        public virtual async Task<TEntity?> GetAsync(
            int? id = null,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Expression<Func<TEntity, TEntity>>? selector = null, bool tracking = false)
        {

            var query = _coreDbContext.Set<TEntity>()
                                       .Filtering(filter)
                                       .Including(include);
            if (!tracking)
                query = query.AsNoTracking();

            var result = (id != null) ? await query.FirstOrDefaultAsync(entity => entity.Id == id) :
                                        await query.FirstOrDefaultAsync();

            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
            int? page = default,
            int? pageSize = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Expression<Func<TEntity, TEntity>>? selector = null)
        {
            var query = _coreDbContext.Set<TEntity>()
                .AsNoTracking()
                .Filtering(filter)
                .Ordering(orderBy)
                .Including(include)
                .Selecting(selector)
                .Paging(page, pageSize);

            return await query.ToListAsync();
        }

        public virtual Task<int> CountAsync() => 
            _coreDbContext.Set<TEntity>().CountAsync();
        
        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> filter) => 
            _coreDbContext.Set<TEntity>().CountAsync(filter);

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var data = await _coreDbContext.Set<TEntity>()
                                           .AsNoTracking()
                                           .AnyAsync(predicate);

            return data;
        }

        #endregion

        #region Writer Methods

        public async Task AddAsync(TEntity entity)
        {
            await _coreDbContext.Set<TEntity>()
                                .AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _coreDbContext.Set<TEntity>()
                          .Update(entity);
        }

        public async Task PatchAsync(TEntity entityEntry)
        {
            var entity = await GetAsync(entityEntry.Id);

            foreach (var toProp in typeof(TEntity).GetProperties())
            {
                var fromProp = typeof(TEntity).GetProperty(toProp.Name);
                var toValue = fromProp?.GetValue(entityEntry, null);
                if (toValue != null)
                {
                    toProp.SetValue(entity, toValue, null);
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);

            if (entity != null)
                _coreDbContext.Set<TEntity>()
                              .Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            _coreDbContext.Set<TEntity>()
                          .Remove(entity);
        }

        public Task SaveChangeAsync() => _coreDbContext.SaveChangesAsync();

        #endregion
    }
}
