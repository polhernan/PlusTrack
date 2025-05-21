
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Application.DTOs.Optimization.Request;
using PlusTrack.API.Application.DTOs.Optimization.Response;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Infrastructure.Exceptions;

namespace PlusTrack.API.Application.Commands.RouteStops.Handlers
{
    public class OrderRouteStopsCommandHandler : IRequestHandler<OrderRouteStopsCommand, List<RouteStop>>
    {


        private readonly PlusTrackDbContext _context;


        public OrderRouteStopsCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task<List<RouteStop>> Handle(OrderRouteStopsCommand request, CancellationToken cancellationToken)
        {
            //! Gets all the route stops for one route by its id
            List<RouteStop> routeStops = _context.RouteStops.Include(x => x.Location).Where(x => x.RouteId.Equals(request.RouteId)).ToList();

            //! If there is no route stops raise a custom exception
            if (!routeStops.Any())
            {
                throw new EntityNotFoundException("No route stops assigned to this route could be found.");
            }

            //! Create the body for the request to the vroom
            Root root = new Root();

            int incremental = 0;

            List<Job> jobs = new List<Job>();

            //! Create dictionaries to relate the response to the entity so we can order them
            var guidToInt = new Dictionary<Guid, int>();
            var intToGuid = new Dictionary<int, Guid>();

            //! Adds the route stops to the body of the request
            routeStops.ForEach(rs =>
            {
                Job job = new Job(rs);
                job.id = incremental++;

                guidToInt[rs.Id] = job.id;
                intToGuid[job.id] = rs.Id;

                jobs.Add(job);
            });

            root.jobs = jobs;

            root.vehicles = new List<Vehicle>();

            root.vehicles.Add(new Vehicle());

            //! Creates an autodisposable HttpClient with the using statement
            using HttpClient httpClient = new HttpClient();

            //! Gets the response and read it as a string
            var response = await (await httpClient.PostAsJsonAsync("http://127.0.0.1:3000/", root))
                .Content.ReadAsByteArrayAsync();

            //! Parse the string response to the object to access the desired data
            List<VroomResponseStep> parsedResponse = JsonSerializer.Deserialize<VroomResponseRoot>(JsonDocument.Parse(response))
                .routes.FirstOrDefault()
                .steps.Where(x => x.type.Equals("job"))
                .ToList();

            //! Incremental to assign the order later in the database
            int stopOrder = 1;

            //! Assign the stop order parsing with the dictionary
            parsedResponse.ForEach(step =>
            {
                Guid rsId = intToGuid[step.id ?? 0];
                routeStops.FirstOrDefault(x => x.Id.Equals(rsId)).StopOrder = stopOrder++;
            });

            //! Save the entity changes
            await _context.SaveChangesAsync();

            return routeStops;
        } 
    }
}
