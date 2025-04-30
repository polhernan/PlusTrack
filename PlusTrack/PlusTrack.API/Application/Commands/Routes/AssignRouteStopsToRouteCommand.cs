namespace PlusTrack.API.Application.Commands.Routes
{
    public class AssignRouteStopsToRouteCommand : IRequest<List<RouteStop>>
    {


        public Guid RouteId { get; }
        public int? AmountOfRouteStops { get; }
        
        
        public AssignRouteStopsToRouteCommand(Guid routeId, int? amountOfRouteStops)
        {
            RouteId = routeId;
            AmountOfRouteStops = amountOfRouteStops;
        }
    }
}
