using MediatR;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Commands.Users
{
    public class CreateUserCommand : IRequest<User>
    {


        public string Name { get; set; }

        public string Surnames { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime BirthDate { get; set; }


        public CreateUserCommand(string name, string surnames, string email, string password, DateTime birthDate)
        {
            Name = name;
            Surnames = surnames;
            Email = email;
            Password = password;
            BirthDate = birthDate;
        }
    }
}
