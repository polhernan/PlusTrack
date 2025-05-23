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
    private readonly IConfiguration _configuration;


    public GetPackagesByUserIdQueryHandler(PlusTrackDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    
    
    public async Task<List<PackageAppDto>> Handle(GetPackagesByUserIdQuery request, CancellationToken cancellationToken)
    {
        //! Get all packages from a specific user
        List<Package> packages = _context.Packages
            .Include(x => x.RouteStop)
            .ThenInclude(x => x.Location)
            .Include(x => x.User)
            .Where(p => p.UserId == request.UserId)
            .ToList();

        //! Initialize HttpClient variable autodisposable with the using
        using HttpClient httpClient = new HttpClient();
        
        //! Create a list of PackageAppDto which is the final object the query will return
        List<PackageAppDto> result = new List<PackageAppDto>();

        //! Iterate over each package of the user
        foreach (var x in packages)
        {
            
            //! For each package of the user, we get the packages will be delivered before and have not been delivered yet
            List<RouteStop> beforePackage = _context.RouteStops
                .Include(y => y.Package)
                .Include(y => y.Location)
                .Where(y => y.RouteId.Equals(x.RouteStop.RouteId) && y.StopOrder <= x.RouteStop.StopOrder && y.Package.Status == (int)PackageStatus.EnReparto)
                .OrderBy(y => y.StopOrder)
                .ToList();

            //! If there are not packages before this one, continue to the next package
            if (beforePackage.Count < 1)
                continue;

            //! We get the route of this package so we can get the last location of the truck and employee
            var route = _context.Routes.Include(y => y.Truck)
                .ThenInclude(y => y.Tracks)
                .ThenInclude(y => y.Location)
                .FirstOrDefault(y => y.Id == x.RouteStop.RouteId);
                
            //! If there is no route so there is a problem, go to the next package
            if(route == null)
                continue;
            
            Truck? truck = route.Truck;
            
            //! If the truck is null so there is a problem, continue to the next package
            if(truck == null) continue;

            //! Gets the entity of the location, ordered by when was the location registred so we can get the las location
            Track? track = truck.Tracks.OrderByDescending(y => y.Moment).FirstOrDefault();

            //! If there is no last location, this means the employee is still on the warehouse and we will return this class
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
            
            //! We assign the location to a new variable to verify is not null
            Location loc = track.Location;
            
            if(loc == null) continue;
            
            //! We create the object that will be sended to ORS (Open Route Service) to know the aproximate time before the deliver
            List<List<double>> coordinates = new List<List<double>>();
            coordinates.Add(new List<double>()
            {
                loc.Longitude,
                loc.Latitude
            });
            
            coordinates.AddRange(beforePackage.Select(y => new List<double>()
            {
                y.Location.Longitude,
                y.Location.Latitude
            }));

            var body = new
            {
                coordinates = beforePackage.Select(y => new double[]
                    { y.Location.Longitude, y.Location.Latitude})
            };

            //! Serialize the request
            string json = JsonSerializer.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            //! Send the request to the ORS service
            var response = await httpClient.PostAsync($"http://{_configuration.GetValue<string>("DockerIps:Ors")}:8080/ors/v2/directions/driving-car", content);

            //! If the response is not successfull, we continue to the next package
            if (!response.IsSuccessStatusCode)
                continue;
            //! If is successfull we parse the response to the response object so we can access the properties
            var parsedResponse = JsonSerializer.Deserialize<Root>((await response.Content.ReadAsStringAsync()));

            //! Parse the returned remaining secconds from the request to time span
            TimeSpan ts = TimeSpan.FromSeconds(parsedResponse.routes.First().summary.duration);
            
            //! We add the object PackageAppDto from the package entity and format the time to deliver from time span            
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