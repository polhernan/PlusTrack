using MediatR;
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;
using PlusTrack.API.Infrastructure.Exceptions;

namespace PlusTrack.API.Application.Queries.Users.Handler
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User?>
    {


        PlusTrackDbContext _context;


        public GetUserByEmailQueryHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task<User?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);


            if (user == null)
                throw new EntityNotFoundException($"User with email {request.Email} was not found.");

            return user;
        }
    }
}
