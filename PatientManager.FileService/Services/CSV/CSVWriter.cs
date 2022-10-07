using CsvHelper;
using CsvHelper.Configuration;
using PatientManager.Application.Interfaces.CSV;
using PatientManager.Domain.Common.Exceptions;
using PatientManager.FileService.Mappings.CSV;
using System.Globalization;
using System.Text;

namespace PatientManager.FileService.Services.CSV
{
    public class CSVWriter : IExportFileCSV
    {
        public async Task<byte[]> WriteDataAsync<T>(IList<T> models)
        {
            if (!models.Any())
                throw new ListEmptyException("Não há registros a serem exportados.");

            var memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream,
                Encoding.GetEncoding("iso-8859-1"));
            
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };
            using var csvWriter = new CsvWriter(writer, config);
            csvWriter.Context.RegisterClassMap<PatientMap>();
            csvWriter.Context.RegisterClassMap<AttendanceMap>();

            csvWriter.WriteHeader<T>();
            await csvWriter.NextRecordAsync();
            await csvWriter.WriteRecordsAsync(models);
            await csvWriter.FlushAsync();

            return memoryStream.ToArray();
        }
    }
}
