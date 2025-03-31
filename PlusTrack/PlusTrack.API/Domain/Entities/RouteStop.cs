namespace PlusTrack.API.Domain.Entities
{
    public class RouteStop
    {
        public Guid Id { get; set; }
        public int StopOrder { get; set; }

        public Route? Route { get; set; }
        public Guid? RouteId { get; set; }

        public Location? Location { get; set; }
        public Guid? LocationId { get; set; }

        public Package? Package { get; set; }
        public Guid? PackageId { get; set; }
    }
}
