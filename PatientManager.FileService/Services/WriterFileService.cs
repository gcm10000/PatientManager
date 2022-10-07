using PatientManager.Application.DTOs;
using PatientManager.Application.Interfaces;
using PatientManager.FileService.Options;

namespace PatientManager.FileService.Services
{
    public class WriterFileService : FileServiceBase, IWriterFileService
    {

        public WriterFileService(FileUriOptions fileUriOptions) : base(fileUriOptions)
        {
        }

        public async Task PublishFileAsync(FileTransfer fileTransfer,
                                                CancellationToken cancellationToken = default)
        {
            var pathFile = GetPath(fileTransfer);
            await File.WriteAllBytesAsync(pathFile, fileTransfer.Data, cancellationToken);
        }

        public Task DeleteFileAsync(FileTransfer fileTransfer, CancellationToken cancellationToken = default)
        {
            File.Delete(GetPath(fileTransfer));
            return Task.CompletedTask;
        }
    }
}