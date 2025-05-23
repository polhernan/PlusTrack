using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlusTrack.API.Application.Commands.Routes;
using PlusTrack.API.Application.Commands.RouteStops;
using PlusTrack.API.Application.DTOs.Routes;
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
        public async Task<ActionResult<List<RouteStop>>> AssignRouteStops(Guid routeId, Guid companyId, int? routeStops)
        {
            var assignRouteStopsToRouteCommand = new AssignRouteStopsToRouteCommand(routeId, companyId, routeStops);

            var result = await bus.Send(assignRouteStopsToRouteCommand);

            return Ok(result);
        }

        [HttpGet("v1/route/get-routes/{companyId:Guid}")]
        public async Task<ActionResult<List<Route>>> GetRoutesByCompanyId(Guid companyId)
        {
            var getAllRoutesByCompanyIdQuery = new GetAllRoutesByCompanyIdQuery(companyId);
            var routes = (await bus.Send(getAllRoutesByCompanyIdQuery));
            
            return Ok(routes);
        }

        [HttpPost("v1/route/create-route-assign-all")]
        public async Task<ActionResult<bool>> CreateRouteAssignAll(CreateRouteRequest request)
        {
            var createRouteCommand = new CreateRouteCommand(DateTime.Now.Date);

            var route = await bus.Send(createRouteCommand);
            
            if(route == null)
                throw new Exception("Error creating route");
            
            var routeStops = (await AssignRouteStops(route.Id, request.CompanyId, request.AmountStops)).Value;
            
            var assignEmployeeTruckToRoute = new AssignEmployeeTruckToRouteCommand(request.EmployeeId,request.TruckId,route.Id);
            await bus.Send(assignEmployeeTruckToRoute);
            
            return Ok(true);
        }

    }
}
