using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlusTrack.API.Application.Commands.Routes;
using PlusTrack.API.Application.Commands.RouteStops;
using PlusTrack.API.Application.Queries.Routes;
using Route = PlusTrack.API.Domain.Entities.Route;

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
        public async Task<ActionResult<List<RouteStop>>> OrderRouteStops(Guid routeId)
        {
            var getRoutesCommand = new OrderRouteStopsCommand(routeId);
            var result = await bus.Send(getRoutesCommand);

            return Ok(result);
        }


        [HttpPost("v1/route/")]
        public async Task<ActionResult<Domain.Entities.Route>> AddRoute(DateTime routeDay)
        {
            var createRouteCommand = new CreateRouteCommand(routeDay);

            var result = await bus.Send(createRouteCommand);

            return Ok(result);
        }
        
        
        [HttpPost("v1/route/assign-route-stops")]
        public async Task<ActionResult<List<RouteStop>>> AssignRouteStops(Guid routeId, int? routeStops)
        {
            var assignRouteStopsToRouteCommand = new AssignRouteStopsToRouteCommand(routeId, routeStops);

            var result = await bus.Send(assignRouteStopsToRouteCommand);

            return Ok(result);
        }

        [HttpGet("v1/route/get-routes/{companyId:Guid}")]
        public async Task<ActionResult<List<Route>>> GetRoutesByCompanyId(Guid companyId)
        {
            var getAllRoutesByCompanyIdQuery = new GetAllRoutesByCompanyIdQuery(companyId);
            var routes = await bus.Send(getAllRoutesByCompanyIdQuery);
            
            return Ok(routes);
        }

    }
}
