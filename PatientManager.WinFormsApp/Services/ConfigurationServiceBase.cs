using PatientManager.Application.DTOs;
using PatientManager.Application.Interfaces;
using System.Text;

namespace PatientManager.WinFormsApp.Services
{
    public abstract class ConfigurationServiceBase
    {
        protected readonly IReaderFileService ReaderFileService;
        protected readonly IWriterFileService WriterFileService;

        protected ConfigurationServiceBase(IReaderFileService readerFileService,
                                       IWriterFileService writerFileService)
        {
            ReaderFileService = readerFileService;
            WriterFileService = writerFileService;
        }

        protected string? GetVariableOrDefaultByGuid(Guid guid)
        {
            var environmentPageSize = Environment.GetEnvironmentVariable(guid.ToString());
            if (environmentPageSize is not null)
                return environmentPageSize;

            var data = ReaderFileService.ReadOrDefaultAsync(new FileTransfer(guid, ".json")).Result;
            if (data is null)
                return null;

            var pageSize = Encoding.UTF8.GetString(data);
            return pageSize;
        }

        protected virtual async Task SetVariableAsync(Guid guid, object value)
        {
            var data = GetBytes(value);
            Environment.SetEnvironmentVariable(guid.ToString(), value.ToString());
            await WriterFileService.PublishFileAsync(new FileTransfer(data, guid, ".json"));
        }

        private static byte[] GetBytes(object value)
        {
            var str = value.ToString();
            if (str is null)
                return Array.Empty<byte>();

            return Encoding.UTF8.GetBytes(str);
        }
    }
}
