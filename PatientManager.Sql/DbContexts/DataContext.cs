using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PatientManager.Domain.Common.Entities;
using PatientManager.Sql.Interceptors;

namespace PatientManager.Sql.DbContexts
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; } = null!;

        public DataContext(IConfiguration configuration, DbContextOptions<DataContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
        {
            _configuration = configuration;
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigureDatabaseProvider(optionsBuilder);
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
        }

        private void ConfigureDatabaseProvider(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("Data");
                optionsBuilder.UseSqlite(connectionString);
            }
        }
    }
}
