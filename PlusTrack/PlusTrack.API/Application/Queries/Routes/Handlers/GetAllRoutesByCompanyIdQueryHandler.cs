using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Domain.AbstractRepositories;
using Route = PlusTrack.API.Domain.Entities.Route;

namespace PlusTrack.API.Application.Queries.Routes.Handlers;

public class GetAllRoutesByCompanyIdQueryHandler : IRequestHandler<GetAllRoutesByCompanyIdQuery, List<Route>>
{
    
    
    private readonly PlusTrackDbContext _context;

    
    public GetAllRoutesByCompanyIdQueryHandler(PlusTrackDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<List<Route>> Handle(GetAllRoutesByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        List<Route> routes = _context.Routes
            .Include(x => x.Truck)
            .Include(x => x.Employee)
            .Where(x => x.Dia.Date.Equals(DateTime.Now.Date)).ToList();

        return routes;
    }
}