using CefSharp.DevTools.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusTrackForms.Models.Entities
{
    public class RouteStop
    {
        public Guid Id { get; set; }
        public int StopOrder { get; set; }
        public Guid? RouteId { get; set; }
        public Location Location { get; set; }
        public Guid LocationId { get; set; }
        public Guid PackageId { get; set; }
    }
}
