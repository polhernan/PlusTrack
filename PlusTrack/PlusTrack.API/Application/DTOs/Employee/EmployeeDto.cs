using System.Text.Json.Serialization;

namespace PlusTrack.API.Application.DTOs.Employee
{
    public class EmployeeDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Dni { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonConstructor]
        public EmployeeDto()
        {
            
        }

        public EmployeeDto(PlusTrack.API.Domain.Entities.Employee employee)
        {
            this.Id = employee.Id;
            this.Name = employee.Name;
            this.Surnames = employee.Surnames;
            this.Dni = employee.Dni;
            this.BirthDate = employee.BirthDate;
            this.Email = employee.Email;
            this.Password = employee.Password;
        }
    }
}
