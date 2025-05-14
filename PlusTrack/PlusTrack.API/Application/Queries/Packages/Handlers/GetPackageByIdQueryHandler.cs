using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Queries.Packages.Handlers;

public class GetPackageByIdQueryHandler : IRequestHandler<GetPackageByIdQuery, Package>
{
    
    
    private readonly PlusTrackDbContext _context;


    public GetPackageByIdQueryHandler(PlusTrackDbContext context)
    {
        _context = context;
    }
    
    
    public Task<Package> Handle(GetPackageByIdQuery request, CancellationToken cancellationToken)
    {
        Package? package = _context.Packages.FirstOrDefault(x => x.Id.Equals(request.PackageId));
        
        if(package == null)
            throw new EntityNotFoundException($"Package with id {request.PackageId} not found");
        
        return Task.FromResult(package);
    }
}