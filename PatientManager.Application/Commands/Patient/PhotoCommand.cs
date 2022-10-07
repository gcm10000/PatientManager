namespace PatientManager.Application.Commands.Patient
{
    public record PhotoCommand : Command
    {
        public string Extension { get; init; }
        public byte[] Data { get; init; }

        public PhotoCommand(string extension, byte[] data)
        {
            Extension = extension;
            Data = data;
        }
    }
}
