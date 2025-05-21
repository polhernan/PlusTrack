namespace PlusTrack.API.Application.Commands.Companies;

public class GetCompanyIdByEmailQuery : IRequest<Guid>
{
    
    
    public string CompanyEmail { get; }

    
    public GetCompanyIdByEmailQuery(string companyEmail)
    {
        CompanyEmail = companyEmail;
    }
}