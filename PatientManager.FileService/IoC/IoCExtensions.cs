using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientManager.Application.Interfaces;
using PatientManager.Application.Interfaces.CSV;
using PatientManager.Application.Interfaces.XLSX;
using PatientManager.FileService.Options;
using PatientManager.FileService.Services;
using PatientManager.FileService.Services.CSV;
using PatientManager.FileService.Services.XLSX;

namespace PatientManager.FileService.IoC
{
    public static class IoCExtensions
    {
        public static IServiceCollection ConfigureFileService(this IServiceCollection serviceCollection, IConfiguration configuration)
            => serviceCollection.AddTransient<IWriterFileService, WriterFileService>()
                                .AddTransient<IReaderFileService, ReaderFileService>()
                                .AddTransient<IReaderFileService, ReaderFileService>()
                                .AddTransient<IExportFileXLSX, XLSXWriter>()
                                .AddTransient<IExportFileCSV, CSVWriter>()
                                .AddTransient(o => new FileUriOptions(configuration.GetSection("FileUriOptions").GetSection("Patient").Value));
    }
}
