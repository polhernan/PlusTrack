using System.Text.Json.Serialization;
using PlusTrack.API.Application.DTOs.Employee;
using PlusTrack.API.Application.Services;

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


        [JsonConstructor]
        public Employee()
        {
            
        }

        public Employee(EmployeeDto snapshot)
        {
            this.Id = snapshot.Id ?? Guid.NewGuid();
            this.Name = snapshot.Name;
            this.Surnames = snapshot.Surnames;
            this.Dni = snapshot.Dni;
            this.BirthDate = snapshot.BirthDate;
            this.Email = snapshot.Email;
            this.Password = Crypter.Hash(snapshot.Password);
        }
    }
}
