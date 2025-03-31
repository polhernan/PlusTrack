using MediatR;
using PlusTrack.API.Application.Commands.Companies;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Commands.Companies.Handlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Company>
    {
        private readonly PlusTrackDbContext _context;

        public CreateCompanyCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task<Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company newCompany = new Company(request.CompanyDto);

            _context.Add(newCompany);

            await _context.SaveChangesAsync();

            return newCompany;
        }
    }
}
