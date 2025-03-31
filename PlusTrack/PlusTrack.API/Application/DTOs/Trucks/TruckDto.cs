using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.DTOs.Trucks
{
    public class TruckDto
    {
        public Guid? Id { get; set; }
        public string Plate { get; set; }
        public DateTime LastItv { get; set; }
        public DateTime NextItv { get; set; }
        public int Capacity { get; set; }
        public Guid? CompanyId { get; set; }

        public TruckDto()
        {
            
        }


        public TruckDto(Truck truck)
        {
            this.Id = truck.Id;
            this.Plate = truck.Plate;
            this.LastItv = truck.LastItv;
            this.NextItv = truck.NextItv;
            this.Capacity = truck.Capacity;
            this.CompanyId = truck.CompanyId;
        }
    }
}
