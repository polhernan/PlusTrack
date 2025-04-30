namespace PlusTrack.API.Application.Commands.Employees
{
    public class AddNewTrackingLocationCommand : IRequest
    {
        
        
        public Guid TruckId { get; }
        public List<double> Location { get; }
        
        
        public AddNewTrackingLocationCommand(Guid truckId, List<double> location)
        {
            TruckId = truckId;
            Location = location;
        }
    }
}
