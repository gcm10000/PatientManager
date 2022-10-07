using MediatR;
using PatientManager.Application.Queries;

namespace PatientManager.Application.Queries.Patient
{
    public record GetPhotoQuery(int Id) : Query(Id), IRequest<byte[]?>;
}
