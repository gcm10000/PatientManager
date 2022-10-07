namespace PatientManager.FileService.Options
{
    public class FileUriOptions
    {
        public string RelativePath { get; set; }

        public FileUriOptions(string relativePath)
        {
            RelativePath = relativePath;
        }
    }
}