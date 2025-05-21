using MediatR;
using PlusTrack.API.Application.DTOs.Licenses;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Commands.Licenses.Handlers
{
    public class CreateLicenseCommandHandler : IRequestHandler<CreateLicenseCommand, LicenseDto>
    {


        public PlusTrackDbContext _context { get; }


        public CreateLicenseCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task<LicenseDto> Handle(CreateLicenseCommand request, CancellationToken cancellationToken)
        {
            //! Create the license entity
            License newLicense = new License(request.LicenseDto);
            
            //! Adds the license entity to the database and save changes
            _context.Add(newLicense);
            await _context.SaveChangesAsync();

            //! Returns the entity dto so it's information can be use
            return new LicenseDto(newLicense);
        }
    }
}
