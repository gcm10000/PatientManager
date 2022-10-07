namespace PatientManager.Application.Commands.Patient
{
    public record UpdateAttendPatientCommand : Command
    {
        public int PatientId { get; init; }
        public int AttendId { get; init; }
        public DateTime Date { get; init; }
    }
}
