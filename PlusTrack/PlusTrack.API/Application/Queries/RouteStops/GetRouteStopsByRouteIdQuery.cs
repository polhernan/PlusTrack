namespace PlusTrack.API.Application.Queries.RouteStops
{
    public class GetRouteStopsByRouteIdQuery : IRequest<List<RouteStop>>
    {
        
        
        public Guid RouteId { get; }
        
        
        public GetRouteStopsByRouteIdQuery(Guid routeId)
        {
            RouteId = routeId;
        }
    }
}
