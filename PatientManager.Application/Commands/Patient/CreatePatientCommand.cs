namespace PatientManager.Application.Commands.Patient
{
    public record CreatePatientCommand : PatientCommand
    {
        public string? GetPhoto(Guid guid)
        {
            if (Photo is not null)
                return guid.ToString() + Photo.Extension;
            return null;
        }
    }
}
