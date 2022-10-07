using Microsoft.EntityFrameworkCore.Storage;
using PatientManager.Application.Interfaces;
using PatientManager.Domain.Common.Interfaces.Repositories;
using PatientManager.Sql.DbContexts;

namespace PatientManager.Sql
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPatientRepository PatientRepository { get; }

        private IDbContextTransaction? _dbContextTransaction;
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext, IPatientRepository patientRepository)
        {
            _dataContext = dataContext;
            PatientRepository = patientRepository;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _dbContextTransaction = await _dataContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_dbContextTransaction == null)
                throw new InvalidOperationException("Begin Transaction is not initialized.");

            await _dataContext.SaveChangesAsync(cancellationToken);
            await _dbContextTransaction.CommitAsync(cancellationToken);
        }

        public void Dispose() => _dbContextTransaction?.Dispose();

        public ValueTask DisposeAsync() => _dbContextTransaction?.DisposeAsync() ?? default;
    }
}
