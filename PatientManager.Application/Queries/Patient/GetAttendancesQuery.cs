using MediatR;
using PatientManager.Domain.Common.DTOs;

namespace PatientManager.Application.Queries.Patient
{
    public record GetAttendancesQuery(int Id, FilterInput FilterInput) : Query(Id), IRequest<PaginatedList<Domain.Common.Entities.Attendance>>;
}
