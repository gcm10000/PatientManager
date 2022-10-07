using Microsoft.Extensions.DependencyInjection;
using PatientManager.Domain.Common.Interfaces.Services;
using PatientManager.Domain.Services;

namespace PatientManager.Domain.IoC
{
    public static class IoCExtensions
    {
        public static IServiceCollection ConfigureDomain(this IServiceCollection serviceCollection)
            => serviceCollection.AddScoped<IPatientService, PatientService>();
    }
}
