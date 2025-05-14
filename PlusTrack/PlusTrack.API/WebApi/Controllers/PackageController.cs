using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cms.Ecc;
using PlusTrack.API.Application.Commands.Packages;
using PlusTrack.API.Application.DTOs.Packages;
using PlusTrack.API.Application.Queries.Packages;

// using PlusTrack.API.Application.Commands.Packages;
// using PlusTrack.API.Application.DTOs.Packages;
// using PlusTrack.API.Application.Queries.Packages;

namespace PlusTrack.API.WebApi.Controllers
{
    [ApiController]
    public class PackageController : Controller
    {


        private readonly ISender bus;


        public PackageController(ISender bus)
        {
            this.bus = bus;
        }


        [HttpPost("v1/packages/")]
        public async Task<ActionResult<Package>> CreatePackage(CreatePackageRequest request)
        {
            var createPackageCommand = new CreatePackageCommand(request);
            Package package = await bus.Send(createPackageCommand);

            return Ok(package);
        }

        [HttpGet("v1/packages/{packageId:guid}")]
        public async Task<ActionResult<Package>> GetPackageById(Guid packageId)
        {
            var getPackageByIdQuery = new GetPackageByIdQuery(packageId);
            Package result = await bus.Send(getPackageByIdQuery);

            return Ok(result);
        }

        [HttpGet("v1/packages/by-user-id/{userId:guid}")]
        public async Task<ActionResult<List<PackageAppDto>>> GetPackageByUserId(Guid userId)
        {
            var getPackagesByUserIdQuery = new GetPackagesByUserIdQuery(userId);
            List<PackageAppDto> res = await bus.Send(getPackagesByUserIdQuery);
            
            return Ok(res);
        }
        
        [HttpGet("v1/packages/next-package-employee/{employeeId:guid}")]
        public async Task<ActionResult<PackageAppDto>> GetNextPackageByEmployeeId(Guid employeeId)
        {
            var getNextPackageByEmployeeIdQuery = new GetNextPackageByEmployeeIdQuery(employeeId);
            PackageAppDto package = await bus.Send(getNextPackageByEmployeeIdQuery);
        
            return Ok(package);
        }
        
        [HttpGet("v1/packages/package-amount/{employeeId:guid}")]
        public async Task<ActionResult<int>> GetPackagesLeftByEmployeeId(Guid employeeId)
        {
            var getPackagesLedtByEmployeeId = new GetPackagesLeftAmountByEmployeeIdQuery(employeeId);
            int amount = await bus.Send(getPackagesLedtByEmployeeId);
        
            return Ok(amount);
        }
        
        [HttpPut("v1/packages/package-status/{packageId:guid}/{status:int}")]
        public async Task<ActionResult> UpdatePackageStatus(Guid packageId, int status)
        {
            var updatePackageStatusCommand = new UpdatePackageStatusCommand(packageId, status);
            await bus.Send(updatePackageStatusCommand);
        
            return Ok();
        }
    }
}
