using PlusTrack.API.Domain.AbstractRepositories;

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
            //! Return the list of companies
            return _context.Companies.ToList();
        }
    }
}
