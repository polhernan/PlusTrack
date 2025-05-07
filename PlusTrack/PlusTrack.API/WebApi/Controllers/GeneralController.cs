using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PlusTrack.API.Application.Commands.General;

namespace PlusTrack.API.WebApi.Controllers
{
    [ApiController]
    public class GeneralController : Controller
    {


        private readonly ISender bus;


        public GeneralController(ISender bus)
        {
            this.bus = bus;
        }


        [HttpPost("v1/general/startup-database")]
        public async Task<ActionResult> StartupDatabase()
        {
            var startupDatabase = new StartupDatabaseCommand();
            await bus.Send(startupDatabase);

            return Ok();
        }

    }
}
