using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Commands.Employees.Handlers
{
    public class AddNewTrackingLocationCommandHandler : IRequestHandler<AddNewTrackingLocationCommand>
    {


        private PlusTrackDbContext _context;

        public AddNewTrackingLocationCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task Handle(AddNewTrackingLocationCommand request, CancellationToken cancellationToken)
        {
            Location? loc = _context.Locations.FirstOrDefault(x => x.Latitude == request.Location.ElementAt(0) && x.Longitude == request.Location.ElementAt(1));


            if (loc == null)
            {
                loc = new Location()
                {
                    Id = Guid.NewGuid(),
                    Longitude = request.Location.ElementAt(0),
                    Latitude = request.Location.ElementAt(1)
                };

                _context.Locations.Add(loc);
            }

            Track track = new Track()
            {
                Id = Guid.NewGuid(),
                LocationId = loc.Id,
                TruckId = request.TruckId
            };

            _context.Tracks.Add(track);

            await _context.SaveChangesAsync();
        }
    }
}
