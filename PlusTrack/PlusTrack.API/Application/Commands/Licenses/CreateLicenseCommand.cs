using MediatR;
using PlusTrack.API.Application.DTOs.Licenses;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Commands.Licenses
{
    public class CreateLicenseCommand : IRequest<LicenseDto>
    {


        public LicenseDto LicenseDto { get; }
        
        
        public CreateLicenseCommand(LicenseDto licenseDto)
        {
            LicenseDto = licenseDto;
        }
    }
}
