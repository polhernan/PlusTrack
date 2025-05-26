using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Application.DTOs.Locations;
using PlusTrack.API.Application.DTOs.Packages;
using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Queries.Packages.Handlers;

public class GetPackageByIdQueryHandler : IRequestHandler<GetPackageByIdQuery, PackageAppDto>
{
    private readonly PlusTrackDbContext _context;
    private readonly IConfiguration _configuration;


    public GetPackageByIdQueryHandler(PlusTrackDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }


    public async Task<PackageAppDto> Handle(GetPackageByIdQuery request, CancellationToken cancellationToken)
    {
        //! Declares a list of packageAppDto
        List<PackageAppDto> result = new List<PackageAppDto>();

        //! Create the variable httpClient autodisposable
        using HttpClient httpClient = new HttpClient();

        //! Get the package by id
        Package? package = _context.Packages
            .Include(y => y.RouteStop)
            .Include(y => y.User)
            .FirstOrDefault(y => y.Id.Equals(request.PackageId));

        if (package.RouteStop.RouteId == null || package.Status != (int)PackageStatus.EnReparto)
        {
            string text = "On the office. Waiting for a driver!";
            if (package.Status == (int)PackageStatus.Entregado)
            {
                text = "The package is been delivered.";
            }else if (package.Status == (int)PackageStatus.Entregado)
            {
                text = "The package couldn't been delivered.";
            }
            return new PackageAppDto()
            {
                Id = package.Id,
                Location = new LocationsDto()
                {
                    Latitude = package.RouteStop.Location.Latitude,
                    Longitude = package.RouteStop.Location.Longitude,
                },
                Status = package.Status,
                Receptor = package.User.Name + " " + package.User.Surnames,
                TimeToDeliver = text
            };
        }

        //! If the package is null raise a custom exception
        if (package == null)
            throw new EntityNotFoundException($"Package with id {request.PackageId} not found");

        //! Gets all the packages before this one to calculate the time to deliver
        List<Package> beforePackage = _context.RouteStops
            .Include(y => y.Package)
                .ThenInclude(y => y.RouteStop)
                .ThenInclude(y => y.Location)
            .Include(y => y.Location)
            .Where(y => y.RouteId.Equals(package.RouteStop.RouteId) && y.StopOrder <= package.RouteStop.StopOrder)
            .OrderBy(y => y.StopOrder)
            .Select(y => y.Package)
            .ToList();

        //! If there is no packages before raise an exception
        if (beforePackage.Count < 1)
            throw new EntityNotFoundException($"Before packages of the package with id {request.PackageId} not found");

        //! gets the route by the route stop id
        var route = _context.Routes.Include(y => y.Truck)
            .ThenInclude(y => y.Tracks)
            .ThenInclude(y => y.Location)
            .FirstOrDefault(y => y.Id == package.RouteStop.RouteId);

        //! Verify the route is not null
        if (route == null)
            throw new EntityNotFoundException($"Route of the package with id {request.PackageId} not found");

        //! Gets the truck from the route
        Truck? truck = route.Truck;

        //! Verify if the truck is not null
        if (truck == null)
            throw new EntityNotFoundException($"Truck of the package with id {request.PackageId} not found");

        //! Gets the last location entity
        Track? track = truck.Tracks.OrderByDescending(y => y.Moment).FirstOrDefault();

        //! If the last location entity is null return the package app dto
        if (track == null)
        {
            return new PackageAppDto()
            {
                Id = package.Id,
                Location = new LocationsDto()
                {
                    Latitude = package.RouteStop.Location.Latitude,
                    Longitude = package.RouteStop.Location.Longitude,
                },
                Status = package.Status,
                Receptor = package.User.Name + " " + package.User.Surnames,
                TimeToDeliver = $"Esperando salida de almacén"
            };
        }

        //! Gets the location entity from the track
        Location loc = track.Location;

        //! If location is null raise a custom exception
        if (loc == null)
            throw new EntityNotFoundException($"Location of the package with id {request.PackageId} not found");

        //! Gets all the before package coordinates and add the employee
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

        //! Creates the body for the request to ORS
        var body = new
        {
            coordinates = beforePackage.Select(y => new double[]
                { y.RouteStop.Location.Longitude, y.RouteStop.Location.Latitude })
        };

        string json = JsonSerializer.Serialize(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync($"http://{_configuration.GetValue<string>("DockerIps:Ors")}:8082/ors/v2/directions/driving-car", content);

        //! If ors response is not succesfull raise an exception
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Time left of the package gave an error");

        //! Parse the response to access the relevant data
        var parsedResponse = JsonSerializer.Deserialize<Root>((await response.Content.ReadAsStringAsync()));

        //! Parse the remaining secconds obtained from the body to a timespan
        TimeSpan ts = TimeSpan.FromSeconds(parsedResponse.routes.First().summary.duration);

        //! Return the object with the needed data
        return new PackageAppDto()
        {
            Id = package.Id,
            Location = new LocationsDto()
            {
                Latitude = package.RouteStop.Location.Latitude,
                Longitude = package.RouteStop.Location.Longitude,
            },
            Status = package.Status,
            Receptor = package.User.Name + " " + package.User.Surnames,
            TimeToDeliver = $"{ts.Hours}h {ts.Minutes}m {ts.Seconds}s"
        };
    }
}