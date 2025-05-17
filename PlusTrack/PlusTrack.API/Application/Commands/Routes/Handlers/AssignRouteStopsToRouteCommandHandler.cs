
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
            var routeStops = _context.RouteStops.Include(x => x.Package).Where(x => x.Package.Status == (int)PackageStatus.EntregaFallida).Take(request.AmountOfRouteStops ?? 20).ToList();
            
            routeStops.AddRange(_context.RouteStops.Include(x => x.Package).Take(request.AmountOfRouteStops - routeStops.Count ?? 20 - routeStops.Count).ToList());

            routeStops.ForEach(rs =>
            {
                rs.RouteId = request.RouteId;
                if(rs.Package != null)
                    rs.Package.Status = 2;
            });

            await _context.SaveChangesAsync();

            return routeStops;
        }
    }
}
