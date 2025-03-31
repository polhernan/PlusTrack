using System.Text.Json.Serialization;
using PlusTrack.API.Application.DTOs.Trucks;

namespace PlusTrack.API.Domain.Entities
{
    public class Truck
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public DateTime LastItv { get; set; }
        public DateTime NextItv { get; set; }
        public int Capacity { get; set; }

        public Company? Company { get; set; }
        public Guid? CompanyId { get; set; }

        public IEnumerable<Route>? Routes { get; set; }

        public IEnumerable<Track>? Tracks { get; set; }

        [JsonConstructor]
        public Truck()
        {
            
        }

        public Truck(TruckDto truckDto)
        {
            this.Id = truckDto.Id ?? Guid.NewGuid();
            this.Plate = truckDto.Plate;
            this.LastItv = truckDto.LastItv;
            this.NextItv = truckDto.NextItv;
            this.Capacity = truckDto.Capacity;
            this.CompanyId = truckDto.CompanyId;

        }
    }
}
