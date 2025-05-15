using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusTrackForms.Models.Entities
{    public class Package
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        //public Nullable<RouteStop> RouteStop { get; set; }
        public Guid? RouteStopId { get; set; }
        public User User { get; set; }
        public Guid? UserId { get; set; }
    }
}
