using PlusTrack.API.Application.DTOs.Packages;

namespace PlusTrack.API.Application.Queries.Packages;

public class GetNextPackageByEmployeeIdQuery : IRequest<PackageAppDto>
{
    
    
    public Guid EmployeeId { get; }

    
    public GetNextPackageByEmployeeIdQuery(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
}