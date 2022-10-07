using PatientManager.Application.DTOs;

namespace PatientManager.Application.Interfaces
{
    public interface IWriterFileService
    {
        Task DeleteFileAsync(FileTransfer fileTransfer, CancellationToken cancellationToken = default);
        Task PublishFileAsync(FileTransfer fileTransfer, CancellationToken cancellationToken = default);
    }
}
