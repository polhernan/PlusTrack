namespace PlusTrack.API.Application.DTOs.Routes;

public class CreateRouteRequest
{
    public Guid EmployeeId { get; set; }
    public Guid TruckId { get; set; }
    public int AmountStops { get; set; }
}