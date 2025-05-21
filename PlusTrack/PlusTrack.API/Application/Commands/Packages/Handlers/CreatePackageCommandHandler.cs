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
        //! Creates the location of the routeStop
        Location newLocation = new Location()
        {
            Id = Guid.NewGuid(),
            Longitude = request.Request.Location.Longitude,
            Latitude = request.Request.Location.Latitude
        };
        
        //! Creates the route stop of the package
        RouteStop newRouteStop = new RouteStop()
        {
            Id = Guid.NewGuid(),
            StopOrder = 0,
            LocationId = newLocation.Id,
        };

        //! Creates the package itself
        Package newPackage = new Package()
        {
            Id = Guid.NewGuid(),
            Status = (int)PackageStatus.Creado,
            UserId = request.Request.UserId,
            RouteStopId = newRouteStop.Id,
            CompanyId = request.Request.CompanyId,
        };
        
        //! Relate the routestop with the package
        newRouteStop.PackageId = newPackage.Id;
        
        //! Save all 3 entities in the database and save changes
        _context.Locations.Add(newLocation);
        _context.RouteStops.Add(newRouteStop);
        _context.Packages.Add(newPackage);
        
        await _context.SaveChangesAsync();
        
        return newPackage;
    }
}