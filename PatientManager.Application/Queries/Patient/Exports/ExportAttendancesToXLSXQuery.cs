using MediatR;

namespace PatientManager.Application.Queries.Patient.Exports
{
    public record ExportAttendancesToXLSXQuery(int PatientId) : IRequest<byte[]>;
}
