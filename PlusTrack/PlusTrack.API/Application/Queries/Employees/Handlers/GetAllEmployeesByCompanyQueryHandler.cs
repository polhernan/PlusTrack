
using Conditions;
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
            request.CompanyId.Requires().IsNotEqualTo(Guid.Empty);

            IEnumerable<Employee> employees = _context.Employees.Where(x => x.CompanyId.Equals(request.CompanyId));

            return Task.FromResult(employees);
        }
    }
}
