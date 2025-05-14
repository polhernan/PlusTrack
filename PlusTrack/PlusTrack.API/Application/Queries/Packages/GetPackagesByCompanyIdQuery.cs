namespace PlusTrack.API.Application.Queries.Packages;

public class GetPackagesByCompanyIdQuery : IRequest<List<Package>> 
{
    
    
    public Guid CompanyId { get; }
    

    public GetPackagesByCompanyIdQuery(Guid companyId)
    {
        CompanyId = companyId;
    }
}