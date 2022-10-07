namespace PatientManager.Application.Commands.Patient
{
    public record PatientCommand : Command
    {
        public string? Name { get; init; }
        public PhotoCommand? Photo { get; init; }
        public string? CPF { get; init; }
        public string? RG { get; init; }
        public string? HealthInsurance { get; init; }
        public long MedicalRecordNumber { get; init; }
    }
}
