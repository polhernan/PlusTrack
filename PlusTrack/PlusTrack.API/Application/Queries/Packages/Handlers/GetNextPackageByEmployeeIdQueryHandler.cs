using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Application.DTOs.Locations;
using PlusTrack.API.Application.DTOs.Packages;
using PlusTrack.API.Domain.AbstractRepositories;
using Route = PlusTrack.API.Domain.Entities.Route;

namespace PlusTrack.API.Application.Queries.Packages.Handlers;

public class GetNextPackageByEmployeeIdQueryHandler : IRequestHandler<GetNextPackageByEmployeeIdQuery, PackageAppDto>
{
    
    
    private readonly PlusTrackDbContext _context;


    public GetNextPackageByEmployeeIdQueryHandler(PlusTrackDbContext context)
    {
        _context = context;
    }
    
    
    public Task<PackageAppDto> Handle(GetNextPackageByEmployeeIdQuery request, CancellationToken cancellationToken)
    {
        var employee = _context.Employees
            .Include(x => x.Routes)
                .ThenInclude(x => x.RouteStops)
                .ThenInclude(x => x.Package)
                .ThenInclude(x => x.User)
            .Include(x => x.Routes)
                .ThenInclude(x => x.RouteStops)
                .ThenInclude(x => x.Location)
            .FirstOrDefault(e => e.Id == request.EmployeeId);
        
        if (employee == null)
            throw new EntityNotFoundException($"Employee with id {request.EmployeeId} does not exist");
        
        Route route = employee.Routes.FirstOrDefault(x => x.Dia.Date.Equals(DateTime.Now.Date));
        
        if(route == null)
            throw new EntityNotFoundException($"Today route for the employee with id {request.EmployeeId} does not exist");

        Package package = route.RouteStops
            .Where(x => x.Package.Status == (int)PackageStatus.EnReparto)
            .OrderBy(x => x.StopOrder)
            .FirstOrDefault()
            .Package;
        
        if(package == null)
            throw new EntityNotFoundException($"Today package for the employee with id {request.EmployeeId} does not exist");
        
        return Task.FromResult(new PackageAppDto()
        {
            Id = package.Id,
            Status = package.Status,
            Receptor = package.User.Name + " " +  package.User.Surnames,
            Location = new LocationsDto()
            {
                Latitude = package.RouteStop.Location.Latitude,
                Longitude = package.RouteStop.Location.Longitude,
            },
        });
    }
}