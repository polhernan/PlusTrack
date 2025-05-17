using System;

namespace PlusTrackForms.Models.RequestModels
{
    public class CreateRouteRequest
    {
        public Guid employeeId { get; set; }
        public Guid truckId { get; set; }
        public int amountStops { get; set; }
    }
}
