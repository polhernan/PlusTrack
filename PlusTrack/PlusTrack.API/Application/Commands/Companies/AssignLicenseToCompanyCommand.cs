using MediatR;

namespace PlusTrack.API.Application.Commands.Companies
{
    public class AssignLicenseToCompanyCommand : IRequest
    {
        public AssignLicenseToCompanyCommand(Guid companyId, Guid licenseId)
        {
            CompanyId = companyId;
            LicenseId = licenseId;
        }

        public Guid CompanyId { get; }
        public Guid LicenseId { get; }
    }
}
