using MediatR;

namespace PatientManager.Application.Commands.Patient.Exports
{
    public record ExportPatientsToCSVQuery : IRequest<byte[]>;
}
