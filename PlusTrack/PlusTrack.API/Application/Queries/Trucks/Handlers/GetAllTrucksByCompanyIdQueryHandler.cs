using MediatR;
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Application.DTOs.Trucks;
using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Queries.Trucks.Handlers
{
    public class GetAllTrucksByCompanyIdQueryHandler : IRequestHandler<GetAllTrucksByCompanyIdQuery, IEnumerable<Truck>>
    {


        private readonly PlusTrackDbContext _context;


        public GetAllTrucksByCompanyIdQueryHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public Task<IEnumerable<Truck>> Handle(GetAllTrucksByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Truck> trucks = _context.Trucks
                .Include(x => x.Routes)
                .Where(x => x.CompanyId.Equals(request.CompanyId))
                .ToList();

            return Task.FromResult(trucks);
        }
    }
}
