using PatientManager.Application.DTOs;

namespace PatientManager.FileService.Extensions
{
    internal static class FileTransferExtensions
    {
        internal static Uri GetUri(this FileTransfer fileTransfer, string relativePath)
        {
            var uriString = string.Join("", relativePath, "/", fileTransfer.Guid.ToString(), fileTransfer.Extension);
            var uri = new Uri(uriString, UriKind.Relative);
            return uri;
        }
    }
}
