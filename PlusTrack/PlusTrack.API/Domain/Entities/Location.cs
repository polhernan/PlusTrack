namespace PlusTrack.API.Domain.Entities
{
    public class Location
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public IEnumerable<Track>? Tracks { get; set; }

        public IEnumerable<RouteStop>? RouteStops { get; set; }

        public IEnumerable<SavedLocation>? SavedLocations { get; set; }
    }
}
