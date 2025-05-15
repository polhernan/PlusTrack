namespace PlusTrack.API.Domain.Entities
{
    public class Package
    {
        public Guid Id { get; set; }
        public int Status { get; set; }

        public RouteStop? RouteStop { get; set; }
        public Guid? RouteStopId { get; set; }

        public User? User { get; set; }
        public Guid? UserId { get; set; }
        
        public Company? Company { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
