namespace PatientManager.Domain.Common.Interfaces.Repositories
{
    public interface IRepositoryWriter<TEntity> where TEntity : IAggregateRoot
    {
        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        Task PatchAsync(TEntity entityEntry);

        Task DeleteAsync(int id);

        void Delete(TEntity entity);

        Task SaveChangeAsync();
    }
}
