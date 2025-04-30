using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlusTrack.API.Application.Commands.Employees;
using PlusTrack.API.Application.Commands.Trucks;
using PlusTrack.API.Application.DTOs.Trucks;

namespace PlusTrack.API.WebApi.Controllers
{
    [ApiController]
    public class TruckController : Controller
    {


        private readonly ISender bus;


        public TruckController(ISender bus)
        {
            this.bus = bus;
        }


        [HttpPost("v1/trucks/")]
        public async Task<ActionResult<TruckDto?>> CreateTruck(TruckDto truckDto)
        {
            var createTruckCommand = new CreateTruckCommand(truckDto);
            var res = await bus.Send(createTruckCommand);

            return Ok(res);
        }

        [HttpPost("v1/trucks/set-ubication")]
        public async Task<ActionResult> SetTrackingLocation(Guid employeeId, List<double> location)
        {
            var addNewTrackingLocation = new AddNewTrackingLocationCommand(employeeId, location);
            await bus.Send(addNewTrackingLocation);

            return Ok();
        }
    }
}
