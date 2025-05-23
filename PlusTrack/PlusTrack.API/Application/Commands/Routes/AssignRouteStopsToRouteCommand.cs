namespace PlusTrack.API.Application.Commands.Routes
{
    public class AssignRouteStopsToRouteCommand : IRequest<List<RouteStop>>
    {


        public Guid RouteId { get; }
        public Guid CompanyId { get; }
        public int? AmountOfRouteStops { get; }
        
        
        public AssignRouteStopsToRouteCommand(Guid routeId, Guid companyId, int? amountOfRouteStops)
        {
            RouteId = routeId;
            CompanyId = companyId;
            AmountOfRouteStops = amountOfRouteStops;
        }
    }
}
