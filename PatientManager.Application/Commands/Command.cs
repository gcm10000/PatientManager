using MediatR;
using PatientManager.Application.Models;

namespace PatientManager.Application.Commands
{
    public abstract record Command : IRequest<Response>
    {
    }
}
