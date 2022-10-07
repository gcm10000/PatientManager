using MediatR;

namespace PatientManager.Application.Queries.Patient.Imports
{
    public record ExportPatientsToXLSXQuery : IRequest<byte[]>;
}
