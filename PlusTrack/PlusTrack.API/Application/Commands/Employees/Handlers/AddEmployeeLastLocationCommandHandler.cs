
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Domain.AbstractRepositories;
using Route = PlusTrack.API.Domain.Entities.Route;

namespace PlusTrack.API.Application.Commands.Employees.Handlers
{
    public class AddEmployeeLastLocationCommandHandler : IRequestHandler<AddEmployeeLastLocationCommand>
    {


        private readonly PlusTrackDbContext _context;


        public AddEmployeeLastLocationCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task Handle(AddEmployeeLastLocationCommand request, CancellationToken cancellationToken)
        {
            //! Get the employee entity from the database by the id, and include routes and truck
            Employee? driver = _context.Employees
                .Include(x => x.Routes)
                .ThenInclude(x => x.Truck)
                .FirstOrDefault(x => x.Id.Equals(request.EmployeeId));

            //! If the driver is not found, throw a custom exception
            if (driver == null)
                throw new EntityNotFoundException($"Employee with id {request.EmployeeId} was not found.");

            //! Gets the today route
            Route? todayRoute = driver.Routes?.FirstOrDefault(x => x.Dia.Date.Equals(DateTime.Now.Date));

            //! If there is no route today, raise a custom exception
            if (todayRoute == null)
                throw new EntityNotFoundException($"Today route from employee could not be found");

            //! Get the truck from the route entity
            Truck? truck = todayRoute.Truck;

            //! If the entity is null, raise a custom exception
            if (truck == null)
                throw new EntityNotFoundException($"Truck from employee could not be found");

            //! Create the location entity with the request data
            Location loc = new Location()
            {
                Id = Guid.NewGuid(),
                Latitude = request.Location.Latitude,
                Longitude = request.Location.Longitude
            };

            //! Create the track entity and add the location id and truck id for the relation in the database
            Track track = new Track()
            {
                Id = Guid.NewGuid(),
                Moment = DateTime.Now,
                LocationId = loc.Id,
                TruckId = truck.Id
            };

            //! Adds both entities in the database and save changes
            _context.Add(loc);
            _context.Add(track);

            await _context.SaveChangesAsync();
        }
    }
}
