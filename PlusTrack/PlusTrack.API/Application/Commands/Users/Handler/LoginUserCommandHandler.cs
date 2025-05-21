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
            //! Get the user from the database
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            //! If user doesn't exist raise custom exception
            if (user == null)
                throw new EntityNotFoundException($"The user with email {request.Email} was not found");

            //! Verify the crypted password match
            if (!Crypter.Verify(request.Password, user.Password ?? ""))
                throw new WrongPasswordException();

            return user;
        }
    }
}
