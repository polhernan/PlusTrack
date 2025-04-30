
using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Commands.Routes.Handlers
{
    public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, Domain.Entities.Route>
    {


        private readonly PlusTrackDbContext _context;


        public CreateRouteCommandHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task<Domain.Entities.Route> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Route route = new Domain.Entities.Route()
            {
                Id = Guid.NewGuid(),
                Dia = request.DayOfRoute
            };

            _context.Routes.Add(route);

            await _context.SaveChangesAsync();

            return route;
        }
    }
}
