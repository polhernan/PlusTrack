using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusTrackForms.Models.Entities
{
    public class SavedLocation
    {
        public Guid Id { get; set; }

        public Location Location { get; set; }
        public Guid? LocationId { get; set; }

        public User User { get; set; }
        public Guid? UserId { get; set; }
    }
}
