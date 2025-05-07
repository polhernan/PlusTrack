
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
            Employee? driver = _context.Employees
                .Include(x => x.Routes)
                .ThenInclude(x => x.Truck)
                .FirstOrDefault(x => x.Id.Equals(request.EmployeeId));

            if (driver == null)
                throw new EntityNotFoundException($"Employee with id {request.EmployeeId} was not found.");

            Route? todayRoute = driver.Routes?.FirstOrDefault(x => x.Dia.Date.Equals(DateTime.Now.Date));

            if (todayRoute == null)
                throw new EntityNotFoundException($"Today route from employee could not be found");

            Truck? truck = todayRoute.Truck;

            if (truck == null)
                throw new EntityNotFoundException($"Truck from employee could not be found");

            Location loc = new Location()
            {
                Id = Guid.NewGuid(),
                Latitude = request.Location.Latitude,
                Longitude = request.Location.Longitude
            };

            Track track = new Track()
            {
                Id = Guid.NewGuid(),
                Moment = DateTime.Now,
                LocationId = loc.Id,
                TruckId = truck.Id
            };

            _context.Add(loc);
            _context.Add(track);

            await _context.SaveChangesAsync();
        }
    }
}
