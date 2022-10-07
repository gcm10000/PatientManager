using MediatR;

namespace PatientManager.Application.Commands.Patient.Exports
{
    public record ExportPatientsToCSVCommand : IRequest<byte[]>;
}
