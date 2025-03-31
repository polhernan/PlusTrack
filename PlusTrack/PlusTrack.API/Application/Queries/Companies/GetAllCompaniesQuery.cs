using MediatR;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Queries.Companies
{
    public class GetAllCompaniesQuery : IRequest<IEnumerable<Company>>
    {

    }
}
