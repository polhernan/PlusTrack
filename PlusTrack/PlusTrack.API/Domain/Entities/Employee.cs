namespace PlusTrack.API.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Dni { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Company? Company { get; set; }
        public Guid? CompanyId { get; set; }

        public IEnumerable<Route>? Routes { get; set; }
    }
}
