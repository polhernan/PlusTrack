using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Queries.Packages.Handlers;

public class GetPackagesByCompanyIdQueryHandler : IRequestHandler<GetPackagesByCompanyIdQuery, List<Package>>
{
    
    
    private readonly PlusTrackDbContext _context;


    public GetPackagesByCompanyIdQueryHandler(PlusTrackDbContext context)
    {
        _context = context;
    }
    
    
    public Task<List<Package>> Handle(GetPackagesByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var packages = _context.Packages
            .Include(x => x.User)
            .Include(x => x.RouteStop)
                .ThenInclude(x => x.Route)
                .ThenInclude(x => x.Truck)
            .Include(x => x.RouteStop)
                .ThenInclude(x => x.Location)
            .Where(x => x.RouteStop.Route.Truck.CompanyId == request.CompanyId)
            .ToList();
        
        return Task.FromResult(packages);
    }
}