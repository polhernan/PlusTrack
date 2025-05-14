using PlusTrack.API.Application.DTOs.Packages;

namespace PlusTrack.API.Application.Commands.Packages;

public class CreatePackageCommand : IRequest<Package>
{
    public CreatePackageRequest Request { get; }

    public CreatePackageCommand(CreatePackageRequest request)
    {
        Request = request;
    }
}