using MediatR;
using PlusTrack.API.Application.DTOs.Trucks;
using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Queries.Trucks.Handlers
{
    public class GetAllTrucksByCompanyIdQueryHandler : IRequestHandler<GetAllTrucksByCompanyIdQuery, IEnumerable<TruckDto>>
    {


        private readonly PlusTrackDbContext _context;


        public GetAllTrucksByCompanyIdQueryHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public Task<IEnumerable<TruckDto>> Handle(GetAllTrucksByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<TruckDto> trucks = _context.Trucks
                .Where(x => x.CompanyId.Equals(request.CompanyId))
                .Select(x => new TruckDto(x))
                .ToList();

            return Task.FromResult(trucks);
        }
    }
}
