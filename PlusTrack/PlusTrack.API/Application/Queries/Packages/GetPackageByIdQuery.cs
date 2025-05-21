using PlusTrack.API.Application.DTOs.Packages;

namespace PlusTrack.API.Application.Queries.Packages;

public class GetPackageByIdQuery : IRequest<PackageAppDto>
{
    
    
    public Guid PackageId { get; }

    
    public GetPackageByIdQuery(Guid packageId)
    {
        PackageId = packageId;
    }
}