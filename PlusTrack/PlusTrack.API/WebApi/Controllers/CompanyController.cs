using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlusTrack.API.Application.Commands.Companies;
using PlusTrack.API.Application.DTOs.Companies;
using PlusTrack.API.Application.Queries.Companies;
using PlusTrack.API.Domain.Entities;
using PlusTrack.API.Infrastructure.Exceptions;


namespace PlusTrack.API.WebApi.Controllers;


[ApiController]
public class CompanyController : Controller
{


    public IMediator bus { get; }


    public CompanyController(IMediator bus)
    {
        this.bus = bus;
    }


    [HttpPost("v1/companies")]
    public async Task<ActionResult<CompanyDto>> AddCompany(CompanyDto snapshot)
    {
        var createCompanyCommand = new CreateCompanyCommand(snapshot);
        CompanyDto result = new CompanyDto(await bus.Send(createCompanyCommand));

        return Ok(result);
    }

    [HttpGet("v1/companies/all")]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAllCompanies()
    {
        var getAllCompaniesQuery = new GetAllCompaniesQuery();
        IEnumerable<CompanyDto> companies = (await bus.Send(getAllCompaniesQuery)).Select(x => new CompanyDto(x));

        return Ok(companies);
    }

    [HttpGet("v1/companies/{companyId:guid}")]
    public async Task<ActionResult<Company>> GetCompanyById(Guid companyId)
    {
        var getCompanyByIdQuery = new GetCompanyByIdQuery(companyId);
        var company = await bus.Send(getCompanyByIdQuery);

        if (company == null)
            throw new EntityNotFoundException($"Entity company with id {companyId} not found");

        return Ok(company);
    }

    [HttpPatch("v1/companies/{companyId:guid}/assign-license/{licenseId:guid}")]
    public async Task<ActionResult> AssignLicenseToCompany(Guid companyId, Guid licenseId)
    {
        var assignLicenseToCompanyCommand = new AssignLicenseToCompanyCommand(companyId, licenseId);
        await bus.Send(assignLicenseToCompanyCommand);

        return Ok();
    }

    [HttpGet("v1/companies/{companyEmail}/license")]
    public async Task<ActionResult<Guid>> GetCompanyIdByEmail(String companyEmail)
    {
        var getCompanyGuidByEmailQuery = new GetCompanyIdByEmailQuery(companyEmail);
        Guid companyId = await bus.Send(getCompanyGuidByEmailQuery);
        
        return companyId;
    }
}
