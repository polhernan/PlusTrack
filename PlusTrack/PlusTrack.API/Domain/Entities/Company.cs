using System.ComponentModel.DataAnnotations.Schema;
using PlusTrack.API.Application.DTOs.Companies;

namespace PlusTrack.API.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Guid? LicenseId { get; set; }
        public License? License { get; set; }

        public IEnumerable<Employee>? Employees { get; set; }

        public IEnumerable<Truck>? Trucks { get; set; }


        private Company()
        {
            
        }


        public Company(CompanyDto snapshot)
        {
            Id = Guid.NewGuid();
            Name = snapshot.Name;
            Email = snapshot.Email;
        }
    }
}
