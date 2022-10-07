using MediatR;

namespace PatientManager.Application.Queries.Patient.Imports
{
    public record ExportPatientsToCSVQuery : IRequest<byte[]>;
}
