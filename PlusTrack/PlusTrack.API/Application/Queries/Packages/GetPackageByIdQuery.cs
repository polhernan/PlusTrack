namespace PlusTrack.API.Application.Queries.Packages;

public class GetPackageByIdQuery : IRequest<Package>
{
    
    
    public Guid PackageId { get; }

    
    public GetPackageByIdQuery(Guid packageId)
    {
        PackageId = packageId;
    }
}