using MediatR;
using PlusTrack.API.Application.DTOs.Trucks;

namespace PlusTrack.API.Application.Commands.Trucks;

public class CreateTruckCommand : IRequest<TruckDto>
{
    
    
    public TruckDto TruckDto { get; }


    public CreateTruckCommand(TruckDto truckDto)
    {
        TruckDto = truckDto;
    }
}
