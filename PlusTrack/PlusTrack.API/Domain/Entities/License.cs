using System.ComponentModel;
using System.Text.Json.Serialization;
using PlusTrack.API.Application.DTOs.Licenses;

namespace PlusTrack.API.Domain.Entities
{
    public class License
    {
        public Guid Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TruckAmount { get; set; }
        public int PeopleAmount { get; set; }
        public float PricePerTruck { get; set; }
        public float PricePerPerson { get; set; }
        public Company? Company { get; set; }


        private License()
        {
            
        }


        public License(LicenseDto licenseDto)
        {
            Id = licenseDto.Id ?? Guid.Empty;
            FromDate = licenseDto.FromDate;
            ToDate = licenseDto.ToDate;
            TruckAmount = licenseDto.TruckAmount;
            PeopleAmount = licenseDto.PeopleAmount;
            PricePerTruck = licenseDto.PricePerTruck;
            PricePerPerson = licenseDto.PricePerPerson;
        }
    }
}
