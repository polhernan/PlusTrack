
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
            
            //// Licenses and Companies
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
            
            
            //// Employees

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

            createEmployeeCommand = new CreateEmployeeCommand(new DTOs.Employee.EmployeeDto()
            {
                Name = "Lorena",
                Surnames = "Bonilla",
                Dni = "87654321O",
                BirthDate = DateTime.Now,
                Email = "ccc",
                Password = "ccc",
                CompanyId = company.Id
            });
            var employee2 = await bus.Send(createEmployeeCommand);

            
            //// Users

            var createUserCommand = new CreateUserCommand("Pol", "Hernan Camino", "aaa", "aaa", DateTime.Now);
            var user = await bus.Send(createUserCommand);

            createUserCommand = new CreateUserCommand("Veronica", "Lainez Liso", "ddd", "ddd", DateTime.Now);
            var user2 = await bus.Send(createUserCommand);
            
            
            //// Trucks

            var createTruckCommand = new CreateTruckCommand(new DTOs.Trucks.TruckDto()
            {
                Plate = "9375MLT",
                LastItv = DateTime.Now,
                NextItv = DateTime.Now.AddDays(365),
                Capacity = 2500,
                CompanyId = company.Id
            });
            var truck = await bus.Send(createTruckCommand);

            createTruckCommand = new CreateTruckCommand(new DTOs.Trucks.TruckDto()
            {
                Plate = "7074LCW",
                LastItv = DateTime.Now,
                NextItv = DateTime.Now.AddDays(365),
                Capacity = 2500,
                CompanyId = company.Id
            });
            var truck2 = await bus.Send(createTruckCommand);
            
            
            //// Packages

            var createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.197508296820809,
                    Latitude = 41.599683992119786
                },
                CompanyId = company.Id
            });

            await bus.Send(createPackageCommand);
            
            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.283197865935019,
                    Latitude = 41.60052122351908
                },
                CompanyId = company.Id
            });

            await bus.Send(createPackageCommand);
            
            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.273132150316063,
                    Latitude = 41.622349136882505
                },
                CompanyId = company.Id
            });

            await bus.Send(createPackageCommand);
            
            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user2.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.273132150316063,
                    Latitude = 41.622349136882505
                },
                CompanyId = company.Id
            });

            await bus.Send(createPackageCommand);
            
            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user2.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.273132150316063,
                    Latitude = 41.622349136882505
                },
                CompanyId = company.Id
            });

            await bus.Send(createPackageCommand);
            
            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user2.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.273132150316063,
                    Latitude = 41.622349136882505
                },
                CompanyId = company.Id
            });

            await bus.Send(createPackageCommand);
            
            
            //// Create Route

            var createRouteCommand = new CreateRouteCommand(DateTime.Now);
            var route = await bus.Send(createRouteCommand);
            
            
            //// Route Stops

            var assignRouteStopsToRouteCommand = new AssignRouteStopsToRouteCommand(route.Id, 3);
            var routeStops = await bus.Send(assignRouteStopsToRouteCommand);

            var orderRouteStopsCommand = new OrderRouteStopsCommand(route.Id);
            await bus.Send(orderRouteStopsCommand);
            
            
            //// Assign Employee To Truck To Route

            var assignEmployeeTruckToRouteCommand = new AssignEmployeeTruckToRouteCommand(employee.Id ?? Guid.Empty, truck.Id ?? Guid.Empty, route.Id);
            await bus.Send(assignEmployeeTruckToRouteCommand);
        }
    }
}
