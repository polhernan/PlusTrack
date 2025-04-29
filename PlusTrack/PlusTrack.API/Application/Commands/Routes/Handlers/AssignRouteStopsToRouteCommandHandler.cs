
using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Commands.Routes.Handlers
{
    public class AssignRouteStopsToRouteCommandHandler : IRequestHandler<AssignRouteStopsToRouteCommand, List<RouteStop>>
    {


        private readonly PlusTrackDbContext _context;


        public AssignRouteStopsToRouteCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task<List<RouteStop>> Handle(AssignRouteStopsToRouteCommand request, CancellationToken cancellationToken)
        {
            var routeStops = _context.RouteStops.Take(request.AmountOfRouteStops ?? 20).ToList();

            routeStops.ForEach(rs =>
            {
                rs.RouteId = request.RouteId;
            });

            await _context.SaveChangesAsync();

            return routeStops;
        }
    }
}
