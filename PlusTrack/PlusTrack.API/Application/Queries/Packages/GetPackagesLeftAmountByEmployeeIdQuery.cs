using PlusTrack.API.Application.DTOs.Packages;

namespace PlusTrack.API.Application.Queries.Packages;

public class GetPackagesLeftAmountByEmployeeIdQuery : IRequest<int>
{
    
    
    public Guid EmployeeId { get; }

    
    public GetPackagesLeftAmountByEmployeeIdQuery(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
}