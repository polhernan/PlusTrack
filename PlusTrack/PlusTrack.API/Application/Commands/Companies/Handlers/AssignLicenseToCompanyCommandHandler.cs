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
            //! Get the company from database
            Company? company = await _context.Companies.FirstOrDefaultAsync(x => x.Id.Equals(request.CompanyId));

            //! If the company doesn't exist raise the entity no found exception with custom message
            if (company == null)
                throw new EntityNotFoundException($"Company with id {request.CompanyId} was not found.");

            //! Gets the license from the database
            License? license = await _context.Licenses.FirstOrDefaultAsync(x => x.Id.Equals(request.LicenseId));

            //! If the license doesn't exist raise the entity not found exception with custom message
            if(license == null)
                throw new EntityNotFoundException($"License with id {request.LicenseId} was not found.");

            //! Relate both tables
            company.LicenseId = license.Id;

            //! Save the changes
            await _context.SaveChangesAsync();
        }
    }
}
