using PatientManager.Application.DTOs;
using PatientManager.Application.Interfaces;
using PatientManager.FileService.Options;

namespace PatientManager.FileService.Services
{
    public class ReaderFileService : FileServiceBase, IReaderFileService
    {

        public ReaderFileService(FileUriOptions fileUriOptions) : base(fileUriOptions)
        {
        }

        public Task<byte[]?> ReadOrDefaultAsync(FileTransfer fileTransfer)
        {
            string pathFile = GetPath(fileTransfer);
            if (!File.Exists(pathFile))
                return Task.FromResult(default(byte[]));

            return File.ReadAllBytesAsync(pathFile);
        }
    }
}
