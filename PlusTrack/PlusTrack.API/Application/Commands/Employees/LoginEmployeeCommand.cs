using MediatR;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Commands.Employees
{
    public class LoginEmployeeCommand : IRequest<Employee>
    {
        
        
        public string Email { get; set; }
        public string Password { get; set; }
        
        
        public LoginEmployeeCommand(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }
    }
}
