using Route = PlusTrack.API.Domain.Entities.Route;

namespace PlusTrack.API.Application.Queries.Routes;

public class GetAllRoutesByCompanyIdQuery : IRequest<List<Route>>
{
    
    
    public Guid CompanyId { get; }

    
    public GetAllRoutesByCompanyIdQuery(Guid companyId)
    {
        CompanyId = companyId;
    }
}