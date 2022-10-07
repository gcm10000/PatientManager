using Microsoft.Extensions.DependencyInjection;
using PatientManager.Application.Interfaces;
using PatientManager.Domain.Common.Interfaces.Repositories;
using PatientManager.Sql.DbContexts;
using PatientManager.Sql.Interceptors;
using PatientManager.Sql.Repositories;

namespace PatientManager.Sql.IoC
{
    public static class IoCExtensions
    {
        public static IServiceCollection ConfigureSql(this IServiceCollection serviceCollection)
                    => serviceCollection.AddDbContext<DataContext>()
                                        .AddScoped<AuditableEntitySaveChangesInterceptor>()
                                        .AddScoped<IPatientRepository, PatientRepository>()
                                        .AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
