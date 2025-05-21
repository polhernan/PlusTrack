
using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Commands.Routes.Handlers
{
    public class AssignEmployeeTruckToRouteCommandHandler : IRequestHandler<AssignEmployeeTruckToRouteCommand>
    {


        private readonly PlusTrackDbContext _context;


        public AssignEmployeeTruckToRouteCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task Handle(AssignEmployeeTruckToRouteCommand request, CancellationToken cancellationToken)
        {
            //! Gets the route from the database by its Id
            Domain.Entities.Route? route = _context.Routes.FirstOrDefault(x => x.Id.Equals(request.RouteId));

            //! If the route was not found, raise a custom exception
            if (route == null)
                throw new EntityNotFoundException($"Route with id {request.RouteId} was not found!");

            //! Relate truck and employee to the route
            route.TruckId = request.TruckId;
            route.EmployeeId = request.EmployeeId;

            //! Save entity changes
            await _context.SaveChangesAsync();
        }
    }
}
