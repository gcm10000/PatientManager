using MediatR;

namespace PatientManager.Application.Queries.Patient
{
    public record GetPatientQuery(int Id) : Query(Id), IRequest<Domain.Common.Entities.Patient>;
}
