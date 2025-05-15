using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusTrackForms.Models.Entities
{
    public class Truck
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public DateTime LastItv { get; set; }
        public DateTime NextItv { get; set; }
        public int Capacity { get; set; }
    }
}
