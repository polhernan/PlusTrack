using System.ComponentModel.DataAnnotations;
using PlusTrack.API.Application.DTOs.Locations;

namespace PlusTrack.API.Application.DTOs.Packages;

public class CreatePackageRequest
{
    public Guid UserId { get; set; }
    
    [Required] public LocationsDto Location { get; set; }
}