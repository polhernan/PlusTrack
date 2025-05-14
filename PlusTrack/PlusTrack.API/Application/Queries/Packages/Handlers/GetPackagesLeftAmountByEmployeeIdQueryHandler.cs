using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Domain.AbstractRepositories;
using Route = PlusTrack.API.Domain.Entities.Route;

namespace PlusTrack.API.Application.Queries.Packages.Handlers;

public class GetPackagesLeftAmountByEmployeeIdQueryHandler : IRequestHandler<GetPackagesLeftAmountByEmployeeIdQuery, int>
{
    
    
    private readonly PlusTrackDbContext _context;

    
    public GetPackagesLeftAmountByEmployeeIdQueryHandler(PlusTrackDbContext context)
    {
        _context = context;
    }
    
    
    public Task<int> Handle(GetPackagesLeftAmountByEmployeeIdQuery request, CancellationToken cancellationToken)
    {
        Route route = _context.Employees
            .Include(x => x.Routes)
            .ThenInclude(x => x.RouteStops)
            .ThenInclude(x => x.Package)
            .FirstOrDefault(x => x.Id.Equals(request.EmployeeId))
            .Routes.FirstOrDefault(x => x.Dia.Date.Equals(DateTime.Now.Date));
        
        if(route == null)
            throw new EntityNotFoundException($"Today route of the employee with id {request.EmployeeId} was not found");

        List<RouteStop> stopsLeft = route.RouteStops.Where(x => x.Package.Status == (int)PackageStatus.EnReparto).ToList();

        return Task.FromResult(stopsLeft.Count);
    }
}