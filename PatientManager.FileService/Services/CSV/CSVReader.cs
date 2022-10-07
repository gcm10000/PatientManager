using CsvHelper;
using CsvHelper.Configuration;
using PatientManager.Application.Interfaces.CSV;
using System.Globalization;
using System.Text;

namespace PatientManager.FileService.Services.CSV
{
    public class CSVReader : IImportFileCSV
    {
        private CsvConfiguration? _csvConfiguration;

        public void SetConfiguration(Encoding encoding)
        {
            _csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                Escape = '\'',
                Encoding = encoding,
                BadDataFound = null
            };
        }

        public async Task<IList<T>> ReadDataAsync<T>(string path)
        {
            if (_csvConfiguration is null)
                throw new ArgumentNullException(nameof(_csvConfiguration), "Configuração não setada.");

            if (!File.Exists(path))
                throw new ArgumentException("Arquivo não encontrado.", path);

            using var reader = new StreamReader(path, _csvConfiguration.Encoding);
            using var csv = new CsvReader(reader, _csvConfiguration);
            var records = csv.GetRecordsAsync<T>();
            try
            {
                var list = await records.ToListAsync();
                return list;
            }
            catch (CsvHelper.MissingFieldException ex)
            {
                throw ex;
            }
        }
    }
}
