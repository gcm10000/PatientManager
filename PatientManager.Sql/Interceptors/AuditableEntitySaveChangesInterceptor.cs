using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PatientManager.Domain.Common.Entities;
using PatientManager.Sql.Extensions;

namespace PatientManager.Sql.Interceptors
{
    public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
    {
        public AuditableEntitySaveChangesInterceptor()
        {

        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            var now = DateTime.Now;

            foreach (var entry in context.ChangeTracker.Entries<Entity>())
            {
                entry.Property(x => x.CreatedAt).IsModified = false;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.SetCreatedAt(now);
                }

                if (entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                {
                    entry.Entity.SetUpdatedAt(now);
                }
            }
        }
    }
}
