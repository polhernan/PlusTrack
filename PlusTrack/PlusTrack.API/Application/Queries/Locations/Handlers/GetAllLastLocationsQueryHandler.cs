using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Application.DTOs.Locations;
using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Queries.Locations.Handlers;

public class GetAllLastLocationsQueryHandler : IRequestHandler<GetAllLastLocationsQuery, List<LocatorDto?>>
{
    private readonly PlusTrackDbContext _context;


    public GetAllLastLocationsQueryHandler(PlusTrackDbContext context)
    {
        _context = context;
    }


    public Task<List<LocatorDto?>> Handle(GetAllLastLocationsQuery request, CancellationToken cancellationToken)
    {
        //! Gets all the last locations from the employee
        var locationWithTruckPlate = _context.Trucks.Include(x => x.Tracks).ThenInclude(x => x.Location)
            .Select(x => new LocatorDto()
                { Location = x.Tracks.OrderByDescending(y => y.Moment).FirstOrDefault().Location, Plate = x.Plate })
            .Where(x => x.Location != null)
            .ToList();

        return Task.FromResult(locationWithTruckPlate);
    }
}