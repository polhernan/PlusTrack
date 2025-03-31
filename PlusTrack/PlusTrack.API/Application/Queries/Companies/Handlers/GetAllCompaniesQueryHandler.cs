using MediatR;
using PlusTrack.API.Application.Queries.Companies;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Queries.Companies.Handlers
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<Company>>
    {


        private readonly PlusTrackDbContext _context;


        public GetAllCompaniesQueryHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Company>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);

            return _context.Companies.ToList();
        }
    }
}
