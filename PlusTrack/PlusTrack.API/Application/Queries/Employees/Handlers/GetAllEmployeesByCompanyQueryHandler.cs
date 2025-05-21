
using Conditions;
using Microsoft.EntityFrameworkCore;
using PlusTrack.API.Domain.AbstractRepositories;

namespace PlusTrack.API.Application.Queries.Employees.Handlers
{
    public class GetAllEmployeesByCompanyQueryHandler : IRequestHandler<GetAllEmployeesByCompanyQuery, IEnumerable<Employee>>
    {


        private readonly PlusTrackDbContext _context;


        public GetAllEmployeesByCompanyQueryHandler(PlusTrackDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Employee>> Handle(GetAllEmployeesByCompanyQuery request, CancellationToken cancellationToken)
        {
            //! Verify the company id is not an empty guid
            request.CompanyId.Requires().IsNotEqualTo(Guid.Empty);

            //! Gets the employees for this company
            IEnumerable<Employee> employees = _context.Employees.Include(x => x.Routes).Where(x => x.CompanyId.Equals(request.CompanyId)).ToList();

            return Task.FromResult(employees);
        }
    }
}
