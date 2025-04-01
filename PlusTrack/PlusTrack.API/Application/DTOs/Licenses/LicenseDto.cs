using System.Text.Json.Serialization;
using PlusTrack.API.Domain.Entities;

namespace PlusTrack.API.Application.DTOs.Licenses
{
    public class LicenseDto
    {
        public Guid? Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TruckAmount { get; set; }
        public int PeopleAmount { get; set; }
        public float PricePerTruck { get; set; }
        public float PricePerPerson { get; set; }


        public LicenseDto()
        {
            
        }


        [JsonConstructor]
        public LicenseDto(Guid? Id, DateTime FromDate, DateTime ToDate, int TruckAmount, int PeopleAmount, float PricePerTruck, float PricePerPerson)
        {
            this.Id = Id;
            this.FromDate = FromDate;
            this.ToDate = ToDate;
            this.TruckAmount = TruckAmount;
            this.PeopleAmount = PeopleAmount;
            this.PricePerTruck = PricePerTruck;
            this.PricePerPerson = PricePerPerson;
        }

        public LicenseDto(License license) 
        {
            Id = license.Id;
            FromDate = license.FromDate;
            ToDate = license.ToDate;
            TruckAmount = license.TruckAmount;
            PeopleAmount = license.PeopleAmount;
            PricePerTruck = license.PricePerTruck;
            PricePerPerson = license.PricePerPerson;
        }
    }
}
