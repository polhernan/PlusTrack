
using Microsoft.EntityFrameworkCore;
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
            //! Gets all the route stops from the packages whos deliver have been failed
            var routeStops = _context.RouteStops.Include(x => x.Package).Where(x => x.Package.Status == (int)PackageStatus.EntregaFallida).Take(request.AmountOfRouteStops ?? 20).ToList();
            
            //! Add to those route stops some more untill fills the amount of route stops
            routeStops.AddRange(_context.RouteStops.Include(x => x.Package).Where(x => x.RouteId == null).Take(request.AmountOfRouteStops - routeStops.Count ?? 20 - routeStops.Count).ToList());

            //! For each route stop, change route id, so it can be related in the database
            routeStops.ForEach(rs =>
            {
                rs.RouteId = request.RouteId;
                if(rs.Package != null)
                    rs.Package.Status = 2;
            });

            //! Save changes in the database
            await _context.SaveChangesAsync();

            return routeStops;
        }
    }
}
