using MediatR;
using PlusTrack.API.Application.DTOs.Employee;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Commands.Employees.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {


        PlusTrackDbContext _context;


        public CreateEmployeeCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = new Employee(request.EmployeeDto);

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return new EmployeeDto(employee);
        }
    }
}
