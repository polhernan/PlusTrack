using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Commands.Packages.Handlers;

public class CreatePackageCommandHandler : IRequestHandler<CreatePackageCommand, Package>
{
    
    
    private readonly PlusTrackDbContext _context;


    public CreatePackageCommandHandler(PlusTrackDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<Package> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
    {
        Location newLocation = new Location()
        {
            Id = Guid.NewGuid(),
            Longitude = request.Request.Location.Longitude,
            Latitude = request.Request.Location.Latitude
        };
        
        RouteStop newRouteStop = new RouteStop()
        {
            Id = Guid.NewGuid(),
            StopOrder = 0,
            LocationId = newLocation.Id,
        };


        Package newPackage = new Package()
        {
            Id = Guid.NewGuid(),
            Status = (int)PackageStatus.Creado,
            UserId = request.Request.UserId,
            RouteStopId = newRouteStop.Id
        };
        
        _context.Locations.Add(newLocation);
        _context.RouteStops.Add(newRouteStop);
        _context.Packages.Add(newPackage);
        
        await _context.SaveChangesAsync();
        
        return newPackage;
    }
}