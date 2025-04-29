
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
            List<RouteStop> routeStops = _context.RouteStops.Include(x => x.Location).Where(x => x.RouteId.Equals(request.RouteId)).ToList();

            if (!routeStops.Any())
            {
                throw new EntityNotFoundException("No route stops assigned to this route could be found.");
            }

            Root root = new Root();

            int incremental = 0;

            List<Job> jobs = new List<Job>();

            var guidToInt = new Dictionary<Guid, int>();
            var intToGuid = new Dictionary<int, Guid>();

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

            HttpClient httpClient = new HttpClient();

            var response = await (await httpClient.PostAsJsonAsync("http://127.0.0.1:3000/", root))
                .Content.ReadAsByteArrayAsync();

            List<VroomResponseStep> parsedResponse = JsonSerializer.Deserialize<VroomResponseRoot>(JsonDocument.Parse(response))
                .routes.FirstOrDefault()
                .steps.Where(x => x.type.Equals("job"))
                .ToList();

            int stopOrder = 1;

            parsedResponse.ForEach(step =>
            {
                Guid rsId = intToGuid[step.id ?? 0];
                routeStops.FirstOrDefault(x => x.Id.Equals(rsId)).StopOrder = stopOrder++;
            });

            await _context.SaveChangesAsync();

            return routeStops;
        } 
    }
}
