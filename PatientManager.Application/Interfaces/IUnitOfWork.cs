namespace PatientManager.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
