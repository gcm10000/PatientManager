namespace PatientManager.Application.Commands.Patient
{
    public record UpdatePatientCommand : PatientCommand
    {
        public int Id { get; init; }
    }
}
