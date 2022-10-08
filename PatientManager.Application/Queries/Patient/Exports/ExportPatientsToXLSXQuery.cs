using MediatR;

namespace PatientManager.Application.Queries.Patient.Exports
{
    public record ExportPatientsToXLSXQuery : IRequest<byte[]>;
}
