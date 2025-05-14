using PlusTrack.API.Application.DTOs.Packages;

namespace PlusTrack.API.Application.Queries.Packages;

public class GetPackagesByUserIdQuery : IRequest<List<PackageAppDto>>
{
    
    
    public Guid UserId { get; }

    
    public GetPackagesByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }
}