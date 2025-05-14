using PlusTrack.API.Application.DTOs.Locations;

namespace PlusTrack.API.Application.DTOs.Packages;

public class PackageAppDto
{
    public Guid Id { get; set; }
    public int Status { get; set; }
    public string TimeToDeliver { get; set; }
    public string Receptor { get; set; }
    public LocationsDto Location { get; set; }
    
}