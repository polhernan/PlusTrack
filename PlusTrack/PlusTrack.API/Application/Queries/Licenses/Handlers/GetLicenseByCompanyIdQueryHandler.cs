using Conditions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Application.DTOs.Licenses;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;
using PlusTrack.API.Infrastructure.Exceptions;

namespace PlusTrack.API.Application.Queries.Licenses.Handlers
{
    public class GetLicenseByCompanyIdQueryHandler : IRequestHandler<GetLicenseByCompanyIdQuery, LicenseDto>
    {
        private readonly PlusTrackDbContext _context;


        public GetLicenseByCompanyIdQueryHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task<LicenseDto> Handle(GetLicenseByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            //! Verify company id is not an empty guid
            request.CompanyId.Requires(nameof(request.CompanyId)).IsNotEqualTo(Guid.Empty);

            //! Gets the license by the company id
            License? license = _context.Licenses
                .Include(x => x.Company)
                .FirstOrDefault(x => x.Company.Id.Equals(request.CompanyId));

            //! Raise a custom exception if license doesn't exist in the database
            if (license == null)
                throw new EntityNotFoundException($"License with company id {request.CompanyId} not found.");

            return new LicenseDto(license);
        }
    }
}