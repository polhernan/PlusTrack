using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlusTrack.API.Application.Commands.Routes;
using PlusTrack.API.Application.Commands.RouteStops;

namespace PlusTrack.API.WebApi.Controllers
{
    [ApiController]
    public class RouteController : Controller
    {


        public IMediator bus { get; }


        public RouteController(IMediator bus)
        {
            this.bus = bus;
        }


        [HttpGet("v1/route/orderRouteStops/{routeId}")]
        public async Task<List<RouteStop>> OrderRouteStops(Guid routeId)
        {
            var getRoutesCommand = new OrderRouteStopsCommand(routeId);
            var result = await bus.Send(getRoutesCommand);

            return result;
        }


        [HttpPost("v1/route/")]
        public async Task<Domain.Entities.Route> AddRoute(DateTime routeDay)
        {
            var createRouteCommand = new CreateRouteCommand(routeDay);

            var result = await bus.Send(createRouteCommand);

            return result;
        }
        
        
        [HttpPost("v1/route/assign-route-stops")]
        public async Task<List<RouteStop>> AssignRouteStops(Guid routeId, int? routeStops)
        {
            var assignRouteStopsToRouteCommand = new AssignRouteStopsToRouteCommand(routeId, routeStops);

            var result = await bus.Send(assignRouteStopsToRouteCommand);

            return result;
        }

    }
}
