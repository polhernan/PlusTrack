namespace PlusTrack.API.Application.Queries.Packages;

public class GetPackagesByRouteIdQuery : IRequest<List<Package>>
{
    
    
    public Guid RouteId { get; }

    
    public GetPackagesByRouteIdQuery(Guid routeId)
    {
        RouteId = routeId;
    }
}