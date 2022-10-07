using PatientManager.Application.DTOs;

namespace PatientManager.Application.Interfaces
{
    public interface IReaderFileService
    {
        Task<byte[]?> ReadOrDefaultAsync(FileTransfer fileTransfer);
    }
}
