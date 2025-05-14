using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Application.DTOs.Locations;
using PlusTrack.API.Application.DTOs.Packages;
using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Queries.Packages.Handlers;

public class GetPackagesByUserIdQueryHandler : IRequestHandler<GetPackagesByUserIdQuery, List<PackageAppDto>>
{
    
    
    private readonly PlusTrackDbContext _context;


    public GetPackagesByUserIdQueryHandler(PlusTrackDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<List<PackageAppDto>> Handle(GetPackagesByUserIdQuery request, CancellationToken cancellationToken)
    {
        List<Package> packages = _context.Packages
            .Include(x => x.RouteStop)
            .ThenInclude(x => x.Location)
            .Include(x => x.User)
            .Where(p => p.UserId == request.UserId)
            .ToList();

        using HttpClient httpClient = new HttpClient();
        
        List<PackageAppDto> result = new List<PackageAppDto>();

        foreach (var x in packages)
        {
            List<Package> beforePackage = _context.RouteStops.Include(y => y.Package)
                .Include(y => y.Location)
                .Where(y => y.RouteId.Equals(x.RouteStop.RouteId) && y.StopOrder <= x.RouteStop.StopOrder)
                .OrderBy(y => y.StopOrder)
                .Select(y => y.Package)
                .ToList();

            if (beforePackage.Count < 1)
                continue;

            var route = _context.Routes.Include(y => y.Truck)
                .ThenInclude(y => y.Tracks)
                .ThenInclude(y => y.Location)
                .FirstOrDefault(y => y.Id == x.RouteStop.RouteId);
            
                //
                // .Truck.Tracks.OrderByDescending(y => y.Moment)
                // .FirstOrDefault()
                // .Location;
                
            if(route == null)
                continue;
            
            Truck? truck = route.Truck;
            
            if(truck == null) continue;

            Track? track = truck.Tracks.OrderByDescending(y => y.Moment).FirstOrDefault();

            if (track == null)
            {
                result.Add(new  PackageAppDto()
                {
                    Id = x.Id,
                    Location = new LocationsDto()
                    {
                        Latitude = x.RouteStop.Location.Latitude,
                        Longitude = x.RouteStop.Location.Longitude,
                    },
                    Status = x.Status,
                    Receptor = x.User.Name + " " + x.User.Surnames,
                    TimeToDeliver = $"Esperando salida de almacén"
                });
                continue;
            }
            
            Location loc = track.Location;
            
            if(loc == null) continue;
            
            List<List<double>> coordinates = new List<List<double>>();
            coordinates.Add(new List<double>()
            {
                loc.Longitude,
                loc.Latitude
            });
            
            coordinates.AddRange(beforePackage.Select(y => new List<double>()
            {
                y.RouteStop.Location.Longitude,
                y.RouteStop.Location.Latitude
            }));

            var body = new
            {
                coordinates = beforePackage.Select(y => new double[]
                    { y.RouteStop.Location.Longitude, y.RouteStop.Location.Latitude})
            };

            string json = JsonSerializer.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:8080/ors/v2/directions/driving-car", content);

            if (!response.IsSuccessStatusCode)
                continue;
            
            var parsedResponse = JsonSerializer.Deserialize<Root>((await response.Content.ReadAsStringAsync()));

            TimeSpan ts = TimeSpan.FromSeconds(parsedResponse.routes.First().summary.duration);
            
            result.Add(new  PackageAppDto()
            {
                Id = x.Id,
                Location = new LocationsDto()
                {
                    Latitude = x.RouteStop.Location.Latitude,
                    Longitude = x.RouteStop.Location.Longitude,
                },
                Status = x.Status,
                Receptor = x.User.Name + " " + x.User.Surnames,
                TimeToDeliver = $"{ts.Hours}h {ts.Minutes}m {ts.Seconds}s"
            });
        };
        
        return result;
    }
}

internal class Summary
{
    public double duration { get; set; }
}

internal class Routes
{
    public Summary summary { get; set; }
}

internal class Root
{
    public List<Routes> routes { get; set; }
}