using MediatR;

namespace PatientManager.Application.Queries.Patient.Imports
{
    public record ExportAttendanceToCSVQuery(int patientId) : IRequest<byte[]>;
}
