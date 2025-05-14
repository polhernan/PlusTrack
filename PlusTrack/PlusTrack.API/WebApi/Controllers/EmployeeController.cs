using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlusTrack.API.Application.Commands.Employees;
using PlusTrack.API.Application.DTOs.Employee;
using PlusTrack.API.Application.DTOs.General;
using PlusTrack.API.Application.DTOs.Locations;
using PlusTrack.API.Application.Queries.Employees;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.WebApi.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {


        private readonly IMediator bus;


        public EmployeeController(IMediator bus)
        {
            this.bus = bus;
        }


        [HttpPost("v1/employees")]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(EmployeeDto employee)
        {
            var createEmployeeCommand = new CreateEmployeeCommand(employee);
            var result = await bus.Send(createEmployeeCommand);

            return Ok(result);
        }

        [HttpPost("v1/employees/login")]
        public async Task<ActionResult<Employee>> LoginEmployee(UserLoginRequest request)
        {
            var loginEmployeeCommand = new LoginEmployeeCommand(request.Email, request.Password);
            var result = await bus.Send(loginEmployeeCommand);

            return Ok(result);
        }

        [HttpPost("v1/employees/add-location/{employeeId:guid}")]
        [EndpointDescription("Adds the last location from an employee.")]
        public async Task<ActionResult> AddLocationEmployee(Guid employeeId, LocationsDto location)
        {
            var addLocationEmployeeCommand = new AddEmployeeLastLocationCommand(employeeId, location);
            await bus.Send(addLocationEmployeeCommand);

            return Ok();
        }

        [HttpGet("v1/employees/by-company/{companyId:guid}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeesByCompanyId(Guid companyId)
        {
            var getEmployeesByCompanyIdQuery = new GetAllEmployeesByCompanyQuery(companyId);
            var employees = await bus.Send(getEmployeesByCompanyIdQuery);
            
            return Ok(employees);
        }
    }
}
