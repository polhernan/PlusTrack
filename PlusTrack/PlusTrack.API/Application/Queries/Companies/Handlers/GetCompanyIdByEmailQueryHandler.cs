using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Commands.Companies.Handlers;

public class GetCompanyIdByEmailQueryHandler : IRequestHandler<GetCompanyIdByEmailQuery, Guid>
{
    
    
    private readonly PlusTrackDbContext _context;

    
    public GetCompanyIdByEmailQueryHandler(PlusTrackDbContext context)
    {
        _context = context;
    }
    
    
    public Task<Guid> Handle(GetCompanyIdByEmailQuery request, CancellationToken cancellationToken)
    {
        //! Gets the company by it's email
        Company? company = _context.Companies.FirstOrDefault(x => x.Email == request.CompanyEmail);
        
        //! If company doesn't exist, raise a custom exception
        if(company == null)
            throw new EntityNotFoundException($"Company with email {request.CompanyEmail} not found");
        
        return Task.FromResult(company.Id);
    }
}