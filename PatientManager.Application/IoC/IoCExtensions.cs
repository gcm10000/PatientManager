using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace PatientManager.Application.IoC
{
    public static class IoCExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection serviceCollection)
            => serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
