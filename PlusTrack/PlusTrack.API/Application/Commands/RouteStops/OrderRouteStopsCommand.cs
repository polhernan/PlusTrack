namespace PlusTrack.API.Application.Commands.RouteStops
{
    public class OrderRouteStopsCommand : IRequest<List<RouteStop>>
    {


        public Guid RouteId { get; }


        public OrderRouteStopsCommand(Guid routeId)
        {
            RouteId = routeId;
        }
    }
}
