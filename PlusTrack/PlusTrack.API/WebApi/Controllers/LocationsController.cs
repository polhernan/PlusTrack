using Microsoft.AspNetCore.Mvc;
using PlusTrack.API.Application.DTOs.Locations;
using PlusTrack.API.Application.Queries.Locations;

namespace PlusTrack.API.WebApi.Controllers;

[ApiController]
public class LocationsController : Controller
{


    private readonly ISender bus;


    public LocationsController(ISender bus)
    {
        this.bus = bus;
    }

    [HttpGet("v1/locations/by-company/{companyId:Guid}")]
    public async Task<ActionResult<List<LocatorDto>>> GetLocationsByCompanyId(Guid companyId)
    {
        var getTrucksByCompanyId = new GetAllLastLocationsQuery(companyId);
        var result =  await bus.Send(getTrucksByCompanyId);
            
        return Ok(result);
    }
    
    
}