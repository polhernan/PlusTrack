using Conditions;
using MediatR;
using PlusTrack.API.Application.DTOs.Trucks;
using PlusTrack.API.Application.Queries.Licenses;
using PlusTrack.API.Application.Queries.Trucks;
using PlusTrack.API.Domain.AbstractRepositories;
using PlusTrack.API.Domain.Entities;
using PlusTrack.API.Infrastructure.Exceptions;

namespace PlusTrack.API.Application.Commands.Trucks.Handlers
{
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, TruckDto>
    {
        private readonly ISender bus;

        public PlusTrackDbContext _context { get; }


        public CreateTruckCommandHandler(PlusTrackDbContext context, ISender bus)
        {
            _context = context;
            this.bus = bus;
        }


        public async Task<TruckDto> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            bool licenseHaveSpace = await verifyLicenseSpace(request.TruckDto.CompanyId ?? Guid.Empty);

            if (!licenseHaveSpace)
                throw new LicenseAtMaxException($"The license of comany {request.TruckDto.CompanyId}, can't handle more trucks");

            Truck newTruck = new Truck(request.TruckDto);

            _context.Trucks.Add(newTruck);

            await _context.SaveChangesAsync();

            return new TruckDto(newTruck);  
        }


        private async Task<bool> verifyLicenseSpace(Guid companyId)
        {
            companyId.Requires().IsNotEqualTo(Guid.Empty);

            var getAllTrucksByCompanyIdQuery = new GetAllTrucksByCompanyIdQuery(companyId);
            int trucksAmount = (await bus.Send(getAllTrucksByCompanyIdQuery)).Count();

            var getLicenseByCompanyIdQuery = new GetLicenseByCompanyIdQuery(companyId);
            int trucksAllowedAmount = (await bus.Send(getLicenseByCompanyIdQuery)).TruckAmount;

            return trucksAllowedAmount > trucksAmount;
        }
    }
}
