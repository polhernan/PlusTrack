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
        //! Gets all the packages by the specified company
        var packages = _context.Packages
            .Include(x => x.User)
            .Include(x => x.RouteStop)
                .ThenInclude(x => x.Location)
            .Where(x => x.CompanyId == request.CompanyId)
            .ToList();
        
        return Task.FromResult(packages);
    }
}