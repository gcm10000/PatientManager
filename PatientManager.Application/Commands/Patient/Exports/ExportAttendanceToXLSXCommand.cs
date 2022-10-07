using MediatR;

namespace PatientManager.Application.Commands.Patient.Exports
{
    public record ExportAttendanceToXLSXCommand(int PatientId) : IRequest<byte[]>;
}
