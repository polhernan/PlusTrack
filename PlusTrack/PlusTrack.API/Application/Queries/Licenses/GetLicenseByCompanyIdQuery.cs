using MediatR;
using PlusTrack.API.Application.DTOs.Licenses;


namespace PlusTrack.API.Application.Queries.Licenses;


public class GetLicenseByCompanyIdQuery : IRequest<LicenseDto>
{
    public GetLicenseByCompanyIdQuery(Guid companyId)
    {
        CompanyId = companyId;
    }


    public Guid CompanyId { get; }
}
