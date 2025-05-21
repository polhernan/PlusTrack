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
            //! Verify if license have space for another employee
            var licenseHaveSpace = await verifyLicenseSpace(request.EmployeeDto.CompanyId ?? Guid.Empty);

            //! If license have not space, raise an error
            if (!licenseHaveSpace)
                throw new LicenseAtMaxException($"The license of comany {request.EmployeeDto.CompanyId}, can't handle more employees");

            //! Create the employee entity
            Employee employee = new Employee(request.EmployeeDto);

            //! Adds the entity to the database and save changes
            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            //! Returns the entity
            return new EmployeeDto(employee);
        }


        private async Task<bool> verifyLicenseSpace(Guid companyId)
        {
            //! Verify that company id is not an empty guid
            companyId.Requires().IsNotEqualTo(Guid.Empty);

            //! Get the amount of employees
            var getAllEmployeesByCompanyIdQuery = new GetAllEmployeesByCompanyQuery(companyId);
            int employeesAmount = (await bus.Send(getAllEmployeesByCompanyIdQuery)).Count();

            //! Get the max amount of employee
            var getLicenseByCompanyIdQuery = new GetLicenseByCompanyIdQuery(companyId);
            int trucksAllowedAmount = (await bus.Send(getLicenseByCompanyIdQuery)).TruckAmount;

            //! Returns if there is space or not
            return trucksAllowedAmount > employeesAmount;
        }
    }
}
