namespace PlusTrack.API.Application.DTOs.Optimization.Request
{
    public class Job
    {
        public int id { get; set; }
        public List<double> location { get; set; }

        public Job(RouteStop rs)
        {
            location = new List<double>();
            location.Add(rs.Location.Longitude);
            location.Add(rs.Location.Latitude);

            this.location = location;
        }
    }
}
