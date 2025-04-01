namespace PlusTrack.API.Domain.Entities
{
    public class SavedLocation
    {
        public Guid Id { get; set; }

        public Location? Location { get; set; }
        public Guid? LocationId { get; set; }

        public User? User { get; set; }
        public Guid? UserId { get; set; }
    }
}
