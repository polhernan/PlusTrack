namespace PlusTrack.API.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }

        public IEnumerable<SavedLocation>? SavedLocations { get; set; }

        public IEnumerable<Package>? Packages { get; set; }
    }
}
