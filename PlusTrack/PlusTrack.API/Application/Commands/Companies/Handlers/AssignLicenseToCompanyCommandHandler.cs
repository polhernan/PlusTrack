using MediatR;
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;
using PlusTrack.API.Infrastructure.Exceptions;

namespace PlusTrack.API.Application.Commands.Companies.Handlers
{
    public class AssignLicenseToCompanyCommandHandler : IRequestHandler<AssignLicenseToCompanyCommand>
    {


        private readonly PlusTrackDbContext _context;


        public AssignLicenseToCompanyCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task Handle(AssignLicenseToCompanyCommand request, CancellationToken cancellationToken)
        {
            Company? company = await _context.Companies.FirstOrDefaultAsync(x => x.Id.Equals(request.CompanyId));

            if (company == null)
                throw new EntityNotFoundException($"Company with id {request.CompanyId} was not found.");

            License? license = await _context.Licenses.FirstOrDefaultAsync(x => x.Id.Equals(request.LicenseId));

            if(license == null)
                throw new EntityNotFoundException($"License with id {request.LicenseId} was not found.");

            company.LicenseId = license.Id;

            await _context.SaveChangesAsync();
        }
    }
}
