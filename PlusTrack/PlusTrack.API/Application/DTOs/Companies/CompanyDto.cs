using System.Text.Json.Serialization;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.DTOs.Companies;

public class CompanyDto
{


    public Guid? CompanyId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }


    [JsonConstructor]
    public CompanyDto(Guid? CompanyId, string Name, string Email)
    {
        this.CompanyId = CompanyId;
        this.Name = Name;
        this.Email = Email;
    }

    public CompanyDto(Company company)
    {
        this.CompanyId = company.Id;
        this.Name = company.Name;
        this.Email = company.Email;
    }
}
