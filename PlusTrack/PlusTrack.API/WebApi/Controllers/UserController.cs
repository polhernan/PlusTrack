using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlusTrack.API.Application.Commands.Users;
using PlusTrack.API.Application.DTOs.General;
using PlusTrack.API.Application.Queries.Users;
using PlusTrack.API.Application.Services;
using PlusTrack.API.Domain.Entities;
using PlusTrack.API.Infrastructure.Exceptions;

namespace PlusTrack.API.WebApi.Controllers
{
    [ApiController]
    public class UserController : Controller
    {


        IMediator bus;


        public UserController(IMediator bus)
        {
            this.bus = bus;
        }


        [HttpPost("v1/users/register")]
        public async Task<ActionResult<User>> RegisterUser(string name, string surnames, string email, string password, DateTime birthDate)
        {
            var createUserCommand = new CreateUserCommand(name, surnames, email, password, birthDate);
            var result = await bus.Send(createUserCommand);
            
            return Ok(result);
        }

        [HttpGet("v1/users/by-email")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var getUserByEmailQuery = new GetUserByEmailQuery(email);
            var result = await bus.Send(getUserByEmailQuery);

            return Ok(result);
        }

        [HttpGet("v1/users/login")]
        public async Task<ActionResult<User>> LoginUser(UserLoginRequest request)
        {
            var loginUserCommand = new LoginUserCommand(request.Email, request.Password);
            var result = await bus.Send(loginUserCommand);

            return Ok(result);
        }
    }
}
