namespace PlusTrack.API.Domain.Entities
{
    public class Package
    {
        public Guid Id { get; set; }
        public int Status { get; set; }

        public RouteStop? RouteStop { get; set; }
        public Guid? RouteStopId { get; set; }
    }
}
