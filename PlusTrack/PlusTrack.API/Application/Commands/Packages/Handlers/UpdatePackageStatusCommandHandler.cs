using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Commands.Packages.Handlers;

public class UpdatePackageStatusCommandHandler : IRequestHandler<UpdatePackageStatusCommand>
{
    
    
    private readonly PlusTrackDbContext _context;


    public UpdatePackageStatusCommandHandler(PlusTrackDbContext context)
    {
        _context = context;
    }
    
    
    public async Task Handle(UpdatePackageStatusCommand request, CancellationToken cancellationToken)
    {
        Package? package = _context.Packages.FirstOrDefault(x => x.Id == request.PackageId);

        if (package == null)
            throw new EntityNotFoundException($"Package with id {request.PackageId} not found");
        
        package.Status = request.Status;
        
        await _context.SaveChangesAsync();
    }
}