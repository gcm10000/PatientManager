using MediatR;

namespace PatientManager.Application.Commands.Patient.Exports
{
    public record ExportAttendancesToCSVCommand(int PatientId) : IRequest<byte[]>;
}
