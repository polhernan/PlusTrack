using MediatR;
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Application.Services;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;
using PlusTrack.API.Infrastructure.Exceptions;

namespace PlusTrack.API.Application.Commands.Users.Handler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {


        PlusTrackDbContext _context;


        public CreateUserCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            bool emailExist = (await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email)) != null;
            
            if (emailExist)
                throw new UserEmailAlredyExist();

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Surnames = request.Surnames,
                Email = request.Email,
                Password = Crypter.Hash(request.Password),
                BirthDate = request.BirthDate
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
