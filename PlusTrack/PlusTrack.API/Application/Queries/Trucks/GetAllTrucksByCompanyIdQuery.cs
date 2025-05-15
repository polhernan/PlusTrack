using System.Collections.Generic;
using MediatR;
using PlusTrack.API.Application.DTOs.Trucks;

namespace PlusTrack.API.Application.Queries.Trucks
{
    public class GetAllTrucksByCompanyIdQuery : IRequest<IEnumerable<Truck>>
    {


        public Guid CompanyId { get; }


        public GetAllTrucksByCompanyIdQuery(Guid companyId)
        {
            CompanyId = companyId;
        }
    }
}
