using MediatR;

namespace PatientManager.Application.Queries.Patient.Exports
{
    public record ExportAttendancesToCSVQuery(int PatientId) : IRequest<byte[]>;
}
