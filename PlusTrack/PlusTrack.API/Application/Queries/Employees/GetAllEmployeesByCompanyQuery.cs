namespace PlusTrack.API.Application.Queries.Employees
{
    public class GetAllEmployeesByCompanyQuery : IRequest<IEnumerable<Employee>>
    {


        public Guid CompanyId { get; }
        
        
        public GetAllEmployeesByCompanyQuery(Guid companyId)
        {
            CompanyId = companyId;
        }
    }
}
