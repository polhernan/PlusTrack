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
            _context.Database.EnsureDeleted();
            await _context.SaveChangesAsync();

            await _context.Database.MigrateAsync();
            await _context.SaveChangesAsync();

            await AddEntities();
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

            var createCompanyCommand =
                new CreateCompanyCommand(new DTOs.Companies.CompanyDto(Guid.NewGuid(), "Seur", "help@seur.com"));
            var company = await bus.Send(createCompanyCommand);

            var assignCompanyLicense = new AssignLicenseToCompanyCommand(company.Id, license.Id ?? Guid.Empty);
            await bus.Send(assignCompanyLicense);


            var createLicenseCommand2 = new CreateLicenseCommand(new DTOs.Licenses.LicenseDto()
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now.AddDays(30),
                TruckAmount = 5,
                PeopleAmount = 5,
                PricePerPerson = 2,
                PricePerTruck = 2
            });
            var license2 = await bus.Send(createLicenseCommand);

            var createCompanyCommand2 =
                new CreateCompanyCommand(new DTOs.Companies.CompanyDto(Guid.NewGuid(), "Correos", "help@correos.com"));
            var company2 = await bus.Send(createCompanyCommand2);

            var assignCompanyLicense2 = new AssignLicenseToCompanyCommand(company2.Id, license2.Id ?? Guid.Empty);
            await bus.Send(assignCompanyLicense2);


            //// Employees

            var createEmployeeCommand = new CreateEmployeeCommand(new DTOs.Employee.EmployeeDto()
            {
                Name = "Ivan",
                Surnames = "Nadal",
                Dni = "12345678I",
                BirthDate = DateTime.Now,
                Email = "worker1@seur.com",
                Password = "aaa",
                CompanyId = company.Id
            });
            var employee = await bus.Send(createEmployeeCommand);

            var createEmployeeCommand2 = new CreateEmployeeCommand(new DTOs.Employee.EmployeeDto()
            {
                Name = "Lorena",
                Surnames = "Bonilla",
                Dni = "87654321O",
                BirthDate = DateTime.Now,
                Email = "worker2@seur.com",
                Password = "aaa",
                CompanyId = company.Id
            });
            var employee2 = await bus.Send(createEmployeeCommand2);

            var createEmployeeCommand3 = new CreateEmployeeCommand(new DTOs.Employee.EmployeeDto()
            {
                Name = "Jose Luis",
                Surnames = "Aniceto",
                Dni = "45612378O",
                BirthDate = DateTime.Now,
                Email = "worker3@seur.com",
                Password = "aaa",
                CompanyId = company.Id
            });
            var employee3 = await bus.Send(createEmployeeCommand3);

            var createEmployeeCommand4 = new CreateEmployeeCommand(new DTOs.Employee.EmployeeDto()
            {
                Name = "Jaime",
                Surnames = "Hernan",
                Dni = "78541236J",
                BirthDate = DateTime.Now,
                Email = "worker2@correos.com",
                Password = "aaa",
                CompanyId = company2.Id
            });
            var employee4 = await bus.Send(createEmployeeCommand4);

            var createEmployeeCommand5 = new CreateEmployeeCommand(new DTOs.Employee.EmployeeDto()
            {
                Name = "Raquel",
                Surnames = "Camino",
                Dni = "87654321O",
                BirthDate = DateTime.Now,
                Email = "worker3@correos.com",
                Password = "aaa",
                CompanyId = company2.Id
            });
            var employee5 = await bus.Send(createEmployeeCommand5);

            var createEmployeeCommand6 = new CreateEmployeeCommand(new DTOs.Employee.EmployeeDto()
            {
                Name = "Celia",
                Surnames = "Pardo",
                Dni = "87654321O",
                BirthDate = DateTime.Now,
                Email = "worker4@correos.com",
                Password = "aaa",
                CompanyId = company2.Id
            });
            var employee6 = await bus.Send(createEmployeeCommand6);


            //// Users

            var createUserCommand =
                new CreateUserCommand("Pol", "Hernan Camino", "user1@gmail.com", "aaa", DateTime.Now);
            var user = await bus.Send(createUserCommand);

            createUserCommand =
                new CreateUserCommand("Veronica", "Lainez Liso", "user2@gmail.com", "aaa", DateTime.Now);
            var user2 = await bus.Send(createUserCommand);

            createUserCommand = new CreateUserCommand("Santiago", "Abascal", "user3@gmail.com", "aaa", DateTime.Now);
            var user3 = await bus.Send(createUserCommand);

            createUserCommand = new CreateUserCommand("Fernando", "Simon", "user4@gmail.com", "aaa", DateTime.Now);
            var user4 = await bus.Send(createUserCommand);

            createUserCommand = new CreateUserCommand("Fernando", "Alonso", "user5@gmail.com", "aaa", DateTime.Now);
            var user5 = await bus.Send(createUserCommand);

            createUserCommand = new CreateUserCommand("Melendi", "Melendrill", "user6@gmail.com", "aaa", DateTime.Now);
            var user6 = await bus.Send(createUserCommand);

            createUserCommand = new CreateUserCommand("Pedro", "Sanchez", "user7@gmail.com", "aaa", DateTime.Now);
            var user7 = await bus.Send(createUserCommand);

            createUserCommand = new CreateUserCommand("Juan", "Magan", "user8@gmail.com", "aaa", DateTime.Now);
            var user8 = await bus.Send(createUserCommand);

            createUserCommand = new CreateUserCommand("Vegetta", "777", "user9@gmail.com", "aaa", DateTime.Now);
            var user9 = await bus.Send(createUserCommand);

            createUserCommand = new CreateUserCommand("Willy", "Rex", "user10@gmail.com", "aaa", DateTime.Now);
            var user10 = await bus.Send(createUserCommand);

            createUserCommand = new CreateUserCommand("Jean", "Paul", "user11@gmail.com", "aaa", DateTime.Now);
            var user11 = await bus.Send(createUserCommand);

            createUserCommand = new CreateUserCommand("Angel", "Hernan", "user12@gmail.com", "aaa", DateTime.Now);
            var user12 = await bus.Send(createUserCommand);


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

            createTruckCommand = new CreateTruckCommand(new DTOs.Trucks.TruckDto()
            {
                Plate = "5089DYS",
                LastItv = DateTime.Now,
                NextItv = DateTime.Now.AddDays(365),
                Capacity = 2500,
                CompanyId = company.Id
            });
            var truck3 = await bus.Send(createTruckCommand);

            createTruckCommand = new CreateTruckCommand(new DTOs.Trucks.TruckDto()
            {
                Plate = "1234BCD",
                LastItv = DateTime.Now,
                NextItv = DateTime.Now.AddDays(365),
                Capacity = 2500,
                CompanyId = company2.Id
            });
            var truck4 = await bus.Send(createTruckCommand);

            createTruckCommand = new CreateTruckCommand(new DTOs.Trucks.TruckDto()
            {
                Plate = "3040LLM",
                LastItv = DateTime.Now,
                NextItv = DateTime.Now.AddDays(365),
                Capacity = 2500,
                CompanyId = company2.Id
            });
            var truck5 = await bus.Send(createTruckCommand);

            createTruckCommand = new CreateTruckCommand(new DTOs.Trucks.TruckDto()
            {
                Plate = "7548MBZ",
                LastItv = DateTime.Now,
                NextItv = DateTime.Now.AddDays(365),
                Capacity = 2500,
                CompanyId = company2.Id
            });
            var truck6 = await bus.Send(createTruckCommand);


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

            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user3.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.2851,
                    Latitude = 41.6069
                },
                CompanyId = company2.Id
            });
            await bus.Send(createPackageCommand);

            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user3.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.2915,
                    Latitude = 41.6098
                },
                CompanyId = company.Id
            });
            await bus.Send(createPackageCommand);

            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user4.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.2793,
                    Latitude = 41.6112
                },
                CompanyId = company.Id
            });
            await bus.Send(createPackageCommand);

            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user5.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.2758,
                    Latitude = 41.6140
                },
                CompanyId = company.Id
            });
            await bus.Send(createPackageCommand);

            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user6.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.2882,
                    Latitude = 41.6161
                },
                CompanyId = company2.Id
            });
            await bus.Send(createPackageCommand);

            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user6.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.2957,
                    Latitude = 41.6104
                },
                CompanyId = company2.Id
            });
            await bus.Send(createPackageCommand);

            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user7.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.2844,
                    Latitude = 41.6017
                },
                CompanyId = company2.Id
            });
            await bus.Send(createPackageCommand);

            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user8.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.2738,
                    Latitude = 41.6082
                },
                CompanyId = company2.Id
            });
            await bus.Send(createPackageCommand);

            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user9.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.2806,
                    Latitude = 41.6200
                },
                CompanyId = company2.Id
            });
            await bus.Send(createPackageCommand);

            createPackageCommand = new CreatePackageCommand(new CreatePackageRequest()
            {
                UserId = user10.Id,
                Location = new DTOs.Locations.LocationsDto()
                {
                    Longitude = 2.2940,
                    Latitude = 41.6053
                },
                CompanyId = company.Id
            });
            await bus.Send(createPackageCommand);


            //// Create Route

            var createRouteCommand = new CreateRouteCommand(DateTime.Now);
            var route = await bus.Send(createRouteCommand);

            createRouteCommand = new CreateRouteCommand(DateTime.Now);
            var route2 = await bus.Send(createRouteCommand);

            createRouteCommand = new CreateRouteCommand(DateTime.Now);
            var route3 = await bus.Send(createRouteCommand);


            //// Route Stops

            var assignRouteStopsToRouteCommand = new AssignRouteStopsToRouteCommand(route.Id, company.Id, 3);
            var routeStops = await bus.Send(assignRouteStopsToRouteCommand);

            var orderRouteStopsCommand = new OrderRouteStopsCommand(route.Id);
            await bus.Send(orderRouteStopsCommand);

            assignRouteStopsToRouteCommand = new AssignRouteStopsToRouteCommand(route2.Id, company.Id,5);
            var routeStops2 = await bus.Send(assignRouteStopsToRouteCommand);

            orderRouteStopsCommand = new OrderRouteStopsCommand(route2.Id);
            await bus.Send(orderRouteStopsCommand);

            assignRouteStopsToRouteCommand = new AssignRouteStopsToRouteCommand(route3.Id, company.Id,2);
            var routeStops3 = await bus.Send(assignRouteStopsToRouteCommand);

            orderRouteStopsCommand = new OrderRouteStopsCommand(route3.Id);
            await bus.Send(orderRouteStopsCommand);


            //// Assign Employee To Truck To Route

            var assignEmployeeTruckToRouteCommand =
                new AssignEmployeeTruckToRouteCommand(employee.Id ?? Guid.Empty, truck.Id ?? Guid.Empty, route.Id);
            await bus.Send(assignEmployeeTruckToRouteCommand);
            
            assignEmployeeTruckToRouteCommand =
                new AssignEmployeeTruckToRouteCommand(employee2.Id ?? Guid.Empty, truck2.Id ?? Guid.Empty, route2.Id);
            await bus.Send(assignEmployeeTruckToRouteCommand);
            
            assignEmployeeTruckToRouteCommand =
                new AssignEmployeeTruckToRouteCommand(employee3.Id ?? Guid.Empty, truck3.Id ?? Guid.Empty, route3.Id);
            await bus.Send(assignEmployeeTruckToRouteCommand);
        }
    }
}