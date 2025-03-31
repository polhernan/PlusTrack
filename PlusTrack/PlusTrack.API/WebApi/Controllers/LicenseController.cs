using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlusTrack.API.Application.Commands.Licenses;
using PlusTrack.API.Application.DTOs.Licenses;

namespace PlusTrack.API.WebApi.Controllers
{
    [ApiController]
    public class LicenseController : Controller
    {


        public IMediator bus { get; }


        public LicenseController(IMediator bus)
        {
            this.bus = bus;
        }


        [HttpPost("/v1/licenses")]
        public async Task<ActionResult<LicenseDto>> AddLicense(LicenseDto licenseDto)
        {
            var createLicenseCommand = new CreateLicenseCommand(licenseDto);
            var result = await bus.Send(createLicenseCommand);

            return Ok(result);
        }
    }
}
