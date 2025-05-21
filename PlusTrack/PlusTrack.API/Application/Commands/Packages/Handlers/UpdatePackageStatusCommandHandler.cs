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
        //! Gets the package from the database
        Package? package = _context.Packages.FirstOrDefault(x => x.Id == request.PackageId);

        //! If the pacakge is null, raise a custom exception
        if (package == null)
            throw new EntityNotFoundException($"Package with id {request.PackageId} not found");
        
        //! Modify the entity
        package.Status = request.Status;
        
        //! Apply the entity changes
        await _context.SaveChangesAsync();
    }
}