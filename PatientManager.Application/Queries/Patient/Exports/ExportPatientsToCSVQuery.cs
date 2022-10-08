using MediatR;

namespace PatientManager.Application.Queries.Patient.Exports
{
    public record ExportPatientsToCSVQuery : IRequest<byte[]>;
}
