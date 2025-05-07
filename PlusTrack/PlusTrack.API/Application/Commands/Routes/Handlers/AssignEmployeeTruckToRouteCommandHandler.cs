
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
            Domain.Entities.Route? route = _context.Routes.FirstOrDefault(x => x.Id.Equals(request.RouteId));

            if (route == null)
                throw new EntityNotFoundException($"Route with id {request.RouteId} was not found!");

            route.TruckId = request.TruckId;
            route.EmployeeId = request.EmployeeId;

            await _context.SaveChangesAsync();
        }
    }
}
