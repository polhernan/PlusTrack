
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Application.Commands.Companies;
using PlusTrack.API.Application.Commands.Employees;
using PlusTrack.API.Application.Commands.Licenses;
using PlusTrack.API.Application.Commands.Packages;
using PlusTrack.API.Application.Commands.Routes;
using PlusTrack.API.Application.Commands.RouteStops;
using PlusTrack.API.Application.Commands.Trucks;
using PlusTrack.API.Application.Commands.Users;
using PlusTrack.API.Application.DTOs.Packages;
using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Commands.General.Handlers
{
    public class StartupDatabaseCommandHandler : IRequestHandler<StartupDatabaseCommand>
    {


        private readonly PlusTrackDbContext _context;
        private readonly ISender bus;


        public StartupDatabaseCommandHandler(PlusTrackDbContext context, ISender bus)
        {
            _context = context;
            this.bus = bus;
        }

        public async Task Handle(StartupDatabaseCommand request, CancellationToken cancellationToken)
        {
            #if DEBUG
                _context.Database.EnsureDeleted();
                await _context.SaveChangesAsync();

                await _context.Database.MigrateAsync();
                await _context.SaveChangesAsync();

                await AddEntities();
            #endif
        }

        public async Task AddEntities()
        {
            var createLicenseCommand = new CreateLicenseCommand(new DTOs.Licenses.LicenseDto()
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now.AddDays(30),
                TruckAmount = 5,
                PeopleAmount = 5,
                PricePerPerson = 2,
                PricePerTruck = 2
            });
            var license = await bus.Send(createLicenseCommand);

            var createCompanyCommand = new CreateCompanyCommand(new DTOs.Companies.CompanyDto(Guid.NewGuid(),"Seur","help@seur.com"));
            var company = await bus.Send(createCompanyCommand);

            var assignCompanyLicense = new AssignLicenseToCompanyCommand(company.Id, license.Id ?? Guid.Empty);
            await bus.Send(assignCompanyLicense);

            var createEmployeeCommand = new CreateEmployeeCommand(new DTOs.Employee.EmployeeDto()
            {
                Name = "Ivan",
                Surnames = "Nadal",
                Dni = "12345678I",
                BirthDate = DateTime.Now,
                Email = "bbb",
                Password = "bbb",
                CompanyId = company.Id
            });
            var employee = await bus.Send(createEmployeeCommand);


            var createUserCommand = new CreateUserCommand("Pol", "Hernan Camino", "aaa", "aaa", DateTime.Now);
            var user = await bus.Send(createUserCommand);

            var createTruckCommand = new CreateTruckCommand(new DTOs.Trucks.TruckDto()
            {
                Plate = "9375MLT",
                LastItv = DateTime.Now,
                NextItv = DateTime.Now.AddDays(365),
                Capacity = 2500,
                CompanyId = company.Id
            });
            var truck = await bus.Send(createTruckCommand);

            var createPackage1Command = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.197508296820809,
                    Latitude = 41.599683992119786
                }
            });

            var createPackage2Command = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.283197865935019,
                    Latitude = 41.60052122351908
                }
            });

            var createPackage3Command = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.273132150316063,
                    Latitude = 41.622349136882505
                }
            });

            await bus.Send(createPackage1Command);
            await bus.Send(createPackage2Command);
            await bus.Send(createPackage3Command);

            var createRouteCommand = new CreateRouteCommand(DateTime.Now);
            var route = await bus.Send(createRouteCommand);

            var assignRouteStopsToRouteCommand = new AssignRouteStopsToRouteCommand(route.Id, 3);
            var routeStops = await bus.Send(assignRouteStopsToRouteCommand);

            var orderRouteStopsCommand = new OrderRouteStopsCommand(route.Id);
            await bus.Send(orderRouteStopsCommand);

            var assignEmployeeTruckToRouteCommand = new AssignEmployeeTruckToRouteCommand(employee.Id ?? Guid.Empty, truck.Id ?? Guid.Empty, route.Id);
            await bus.Send(assignEmployeeTruckToRouteCommand);
        }
    }
}
