namespace PlusTrack.API.Domain.Entities
{
    public class Route
    {
        public Guid Id { get; set; }
        public DateTime Dia { get; set; }    

        public Employee? Employee { get; set; }
        public Guid? EmployeeId { get; set; }

        public Truck? Truck { get; set; }
        public Guid? TruckId { get; set; }

        public IEnumerable<RouteStop>? RouteStops { get; set; }
    }
}
