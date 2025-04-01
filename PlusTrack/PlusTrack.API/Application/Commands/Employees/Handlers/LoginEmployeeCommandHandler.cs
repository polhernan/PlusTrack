using MediatR;
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Application.Services;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;
using PlusTrack.API.Infrastructure.Exceptions;

namespace PlusTrack.API.Application.Commands.Employees.Handlers
{
    public class LoginEmployeeCommandHandler : IRequestHandler<LoginEmployeeCommand, Employee>
    {


        private readonly PlusTrackDbContext _context;


        public LoginEmployeeCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Handle(LoginEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await _context.Employees.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (employee == null)
                throw new EntityNotFoundException($"The employee with email {request.Email} was not found");

            if (!Crypter.Verify(request.Password, employee.Password))
                throw new WrongPasswordException();

            return employee;
        }
    }
}
