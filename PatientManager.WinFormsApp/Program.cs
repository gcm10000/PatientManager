using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientManager.Application.IoC;
using PatientManager.Domain.IoC;
using PatientManager.FileService.IoC;
using PatientManager.Sql.IoC;
using PatientManager.WinFormsApp.Forms;
using PatientManager.WinFormsApp.IoC;

namespace PatientManager.WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var services = CreateHostBuilder().Build().Services;
            var formMain = services.GetService<FormMain>();

            System.Windows.Forms.Application.Run(formMain);
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostContext, configBuilder) =>
                {
                    configBuilder
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .Build();
                })
                .ConfigureServices((context, services) => {
                    services.ConfigureWinFormsApp();
                    services.ConfigureApplication();
                    services.ConfigureDomain();
                    services.ConfigureSql();
                    services.ConfigureFileService(context.Configuration);
                });
        }
    }
}