namespace PatientManager.Application.Commands.Patient
{
    public record DeleteAttendPatientCommand : Command
    {
        public int PatientId { get; init; }
        public int AttendId { get; init; }
    }
}
