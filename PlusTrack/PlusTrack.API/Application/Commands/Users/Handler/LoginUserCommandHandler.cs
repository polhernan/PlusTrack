using MediatR;
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Application.Services;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;
using PlusTrack.API.Infrastructure.Exceptions;

namespace PlusTrack.API.Application.Commands.Users.Handler
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, User>
    {


        PlusTrackDbContext _context;


        public LoginUserCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task<User> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user == null)
                throw new EntityNotFoundException($"The user with email {request.Email} was not found");

            if (!Crypter.Verify(request.Password, user.Password ?? ""))
                throw new WrongPasswordException();

            return user;
        }
    }
}
