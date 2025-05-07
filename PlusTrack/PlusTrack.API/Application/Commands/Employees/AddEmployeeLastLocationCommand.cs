using PlusTrack.API.Application.DTOs.Locations;

namespace PlusTrack.API.Application.Commands.Employees
{
    public class AddEmployeeLastLocationCommand : IRequest
    {


        public Guid EmployeeId { get; }
        
        public LocationsDto Location { get; }
        
        
        public AddEmployeeLastLocationCommand(Guid employeeId, LocationsDto location)
        {
            EmployeeId = employeeId;
            Location = location;
        }
    }
}
