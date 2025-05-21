using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Application.Services;
using PlusTrack.API.Domain.AbstractRepositories;

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
            //! Gets the entity with the request email
            Employee? employee = await _context.Employees.FirstOrDefaultAsync(x => x.Email == request.Email);

            //! If the employee doesn't exist raise a custom exception
            if (employee == null)
                throw new EntityNotFoundException($"The employee with email {request.Email} was not found");

            //! Verify if the password hash and the password provided are equivalent if not throw a custom exception
            if (!Crypter.Verify(request.Password, employee.Password))
                throw new WrongPasswordException();

            //! Returns the entity
            return employee;
        }
    }
}
