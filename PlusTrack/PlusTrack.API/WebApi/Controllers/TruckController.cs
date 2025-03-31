using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}
