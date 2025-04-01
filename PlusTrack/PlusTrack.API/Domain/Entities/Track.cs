namespace PlusTrack.API.Domain.Entities
{
    public class Track
    {
        public Guid Id { get; set; }
        public DateTime Moment { get; set; }

        public Truck? Truck { get; set; }
        public Guid? TruckId { get; set; }

        public Location? Location { get; set; }
        public Guid? LocationId { get; set; }
    }
}
