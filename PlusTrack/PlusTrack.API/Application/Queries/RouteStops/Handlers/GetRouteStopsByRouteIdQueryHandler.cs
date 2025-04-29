
using Conditions;
using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Queries.RouteStops.Handlers
{
    public class GetRouteStopsByRouteIdQueryHandler : IRequestHandler<GetRouteStopsByRouteIdQuery, List<RouteStop>>
    {


        private readonly PlusTrackDbContext _context;


        public GetRouteStopsByRouteIdQueryHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public Task<List<RouteStop>> Handle(GetRouteStopsByRouteIdQuery request, CancellationToken cancellationToken)
        {
            request.RouteId.Requires().IsNotEqualTo(Guid.Empty);

            List<RouteStop> routeStops = _context.RouteStops.Where(x => x.RouteId.Equals(request.RouteId)).ToList();

            return Task.FromResult(routeStops);
        }
    }
}
