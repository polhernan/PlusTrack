using Conditions;
using MediatR;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.Queries.Companies
{
    public class GetCompanyByIdQuery : IRequest<Company?>
    {
        public GetCompanyByIdQuery(Guid companyId)
        {
            companyId.Requires(nameof(companyId)).IsNotEqualTo(Guid.Empty);

            CompanyId = companyId;
        }

        public Guid CompanyId { get; }
    }
}
