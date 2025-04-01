using MediatR;
using PlusTrack.API.Application.DTOs.Employee;

namespace PlusTrack.API.Application.Commands.Employees
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {


        public EmployeeDto EmployeeDto { get; set; }


        public CreateEmployeeCommand(EmployeeDto employeeDto)
        {
            EmployeeDto = employeeDto;
        }
    }
}
