namespace PlusTrack.API.Application.Commands.Packages;

public class UpdatePackageStatusCommand : IRequest
{
    
    public Guid PackageId { get; }
    
    public int Status { get; }

    
    public UpdatePackageStatusCommand(Guid packageId, int status)
    {
        PackageId = packageId;
        Status = status;
    }
}