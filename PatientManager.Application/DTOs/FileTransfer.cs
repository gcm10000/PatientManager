namespace PatientManager.Application.DTOs
{
    public record FileTransfer
    {
        public byte[]? Data { get; }
        public Guid Guid { get; }
        public string Extension { get; }

        public FileTransfer(byte[] Data, Guid Guid, string Extension)
        {
            this.Data = Data;
            this.Guid = Guid;
            this.Extension = Extension;
        }

        public FileTransfer(Guid Guid, string Extension)
        {
            this.Guid = Guid;
            this.Extension = Extension;
        }

        public FileTransfer(string fileName)
        {
            var indexExtension = fileName.LastIndexOf('.');
            if (indexExtension == -1)
                throw new ArgumentException("Extensão não encontrada.");
            var guidFileName = fileName.Substring(0, indexExtension);
            this.Guid = Guid.Parse(guidFileName);
            this.Extension = Path.GetExtension(fileName);
        }
    }
}
