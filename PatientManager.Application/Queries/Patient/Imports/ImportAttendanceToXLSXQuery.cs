using MediatR;

namespace PatientManager.Application.Queries.Patient.Imports
{
    public record ExportAttendanceToXLSXQuery(int PatientId) : IRequest<byte[]>;
}
