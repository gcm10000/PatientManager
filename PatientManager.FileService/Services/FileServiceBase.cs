using PatientManager.Application.DTOs;
using PatientManager.FileService.Extensions;
using PatientManager.FileService.Options;

namespace PatientManager.FileService.Services
{
    public abstract class FileServiceBase
    {
        protected readonly FileUriOptions FileUriOptions;
        protected readonly string DirectoryFiles;

        public FileServiceBase(FileUriOptions fileUriOptions)
        {
            FileUriOptions = fileUriOptions;
            DirectoryFiles = Directory.GetCurrentDirectory();
            CreateDirectoryIfNotExists(DirectoryFiles);
        }

        protected string GetPath(FileTransfer fileTransfer)
        {
            var relativePath = FileUriOptions.RelativePath;
            var uri = fileTransfer.GetUri(relativePath);
            var pathFile = Path.Combine(DirectoryFiles, uri.ToString()).Replace('/', '\\');
            CreateDirectoryIfNotExists(Path.GetDirectoryName(pathFile));
            return pathFile;
        }
        
        protected static void CreateDirectoryIfNotExists(string? pathDirectory)
        {
            if (!string.IsNullOrWhiteSpace(pathDirectory) && !Directory.Exists(pathDirectory))
                Directory.CreateDirectory(pathDirectory);
        }
    }
}
