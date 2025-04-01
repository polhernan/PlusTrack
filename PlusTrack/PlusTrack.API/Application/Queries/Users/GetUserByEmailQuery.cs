using MediatR;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Queries.Users
{
    public class GetUserByEmailQuery : IRequest<User?>
    {
        
        
        public string Email { get; }


        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
