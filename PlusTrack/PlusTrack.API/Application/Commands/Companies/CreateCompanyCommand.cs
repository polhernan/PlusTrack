using MediatR;
using PlusTrack.API.Application.DTOs.Companies;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Commands.Companies;

public class CreateCompanyCommand : IRequest<Company>
{


    public CompanyDto CompanyDto { get; }


    public CreateCompanyCommand(CompanyDto companyDto)
    {
        CompanyDto = companyDto;
    }
}
