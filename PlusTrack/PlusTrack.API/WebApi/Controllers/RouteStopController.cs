using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlusTrack.API.WebApi.Controllers
{
    [ApiController]
    public class RouteStopController : Controller
    {


        public IMediator bus { get; }


        public RouteStopController(IMediator bus)
        {
            this.bus = bus;
        }


        
    }
}
