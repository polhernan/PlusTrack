namespace PlusTrack.API.Application.Commands.Routes
{
    public class AssignEmployeeTruckToRouteCommand : IRequest
    {
        public AssignEmployeeTruckToRouteCommand(Guid employeeId, Guid truckId, Guid routeId)
        {
            EmployeeId = employeeId;
            TruckId = truckId;
            RouteId = routeId;
        }

        public Guid EmployeeId { get; }
        public Guid TruckId { get; }
        public Guid RouteId { get; }
    }
}
