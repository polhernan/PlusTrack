using Conditions;
using MediatR;
using PlusTrack.API.Application.DTOs.Employee;
using PlusTrack.API.Application.Queries.Employees;
using PlusTrack.API.Application.Queries.Licenses;
using PlusTrack.API.Application.Queries.Trucks;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Commands.Employees.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {


        private readonly PlusTrackDbContext _context;
        private readonly ISender bus;

        public CreateEmployeeCommandHandler(PlusTrackDbContext context, ISender bus)
        {
            _context = context;
            this.bus = bus;
        }


        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var licenseHaveSpace = await verifyLicenseSpace(request.EmployeeDto.CompanyId ?? Guid.Empty);

            if (!licenseHaveSpace)
                throw new LicenseAtMaxException($"The license of comany {request.EmployeeDto.CompanyId}, can't handle more employees");

            Employee employee = new Employee(request.EmployeeDto);

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return new EmployeeDto(employee);
        }


        private async Task<bool> verifyLicenseSpace(Guid companyId)
        {
            companyId.Requires().IsNotEqualTo(Guid.Empty);

            var getAllEmployeesByCompanyIdQuery = new GetAllEmployeesByCompanyQuery(companyId);
            int trucksAmount = (await bus.Send(getAllEmployeesByCompanyIdQuery)).Count();

            var getLicenseByCompanyIdQuery = new GetLicenseByCompanyIdQuery(companyId);
            int trucksAllowedAmount = (await bus.Send(getLicenseByCompanyIdQuery)).TruckAmount;

            return trucksAllowedAmount > trucksAmount;
        }
    }
}
