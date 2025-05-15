using PlusTrack.API.Application.DTOs.Locations;

namespace PlusTrack.API.Application.Queries.Locations;

public class GetAllLastLocationsQuery : IRequest<List<LocatorDto>>
{
    
    
    public Guid CompanyId { get; }

    
    public GetAllLastLocationsQuery(Guid companyId)
    {
        CompanyId = companyId;
    }
}