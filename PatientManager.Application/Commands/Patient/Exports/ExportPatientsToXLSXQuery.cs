using MediatR;

namespace PatientManager.Application.Commands.Patient.Exports
{
    public record ExportPatientsToXLSXQuery : IRequest<byte[]>;
}
