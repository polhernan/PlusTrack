using MediatR;
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Queries.Companies.Handlers
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, Company?>
    {


        public PlusTrackDbContext _context { get; }
        

        public GetCompanyByIdQueryHandler(PlusTrackDbContext context)
        {
            _context = context;
        }


        public async Task<Company?> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            //! Gets the company and include license and all the trucks related
            var company = await _context.Companies
                .Include(x => x.License)
                .Include(x => x.Trucks)
                .FirstOrDefaultAsync(x => x.Id.Equals(request.CompanyId));

            return company;
        }
    }
}
