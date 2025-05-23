using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Domain.AbstractRepositories;
using Route = PlusTrack.API.Domain.Entities.Route;

namespace PlusTrack.API.Application.Queries.Packages.Handlers;

public class GetPackagesByRouteIdQueryHandler : IRequestHandler<GetPackagesByRouteIdQuery, List<Package>>
{
    
    
    private readonly PlusTrackDbContext _context;

    
    public GetPackagesByRouteIdQueryHandler(PlusTrackDbContext context)
    {
        _context = context;
    }
    
    
    public Task<List<Package>> Handle(GetPackagesByRouteIdQuery request, CancellationToken cancellationToken)
    {
        //! Gets the route
        Route route = _context.Routes
            .Include(x => x.RouteStops)
            .ThenInclude(x => x.Package)
            .ThenInclude(x => x.User)
            .Include(x => x.RouteStops)
            .FirstOrDefault(x => x.Id == request.RouteId);
        
        //! If route is null raise a custom error
        if(route == null)
            throw new EntityNotFoundException("Route with id " + request.RouteId + " not found");
        
        //! Return the packages
        return Task.FromResult(route.RouteStops.Select(x => x.Package).ToList());
    }
}