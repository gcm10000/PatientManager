using Microsoft.Extensions.DependencyInjection;
using PatientManager.WinFormsApp.Controllers;
using PatientManager.WinFormsApp.Forms;
using PatientManager.WinFormsApp.Helpers;
using PatientManager.WinFormsApp.Interfaces;
using PatientManager.WinFormsApp.Services;

namespace PatientManager.WinFormsApp.IoC
{
    public static class IoCExtensions
    {
        public static IServiceCollection ConfigureWinFormsApp(this IServiceCollection serviceCollection)
            => serviceCollection.AddTransient<FormMain>()
                                .AddTransient<FormAddOrUpdatePatient>()
                                .AddTransient<PatientController>()
                                .AddTransient<FormUpdateAttendance>()
                                .AddTransient<FormViewPatient>()
                                .AddTransient<FormConfigurePageSize>()
                                .AddTransient<FormConfigureCamera>()
                                .AddTransient<IPageSizeService, PageSizeConfigurationService>()
                                .AddTransient<ICameraConfigurationService, CameraConfigurationService>()
                                .AddTransient<CameraService>()
                                .AddTransient<FormAttendances>();
    }
}
