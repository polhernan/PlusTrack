namespace PlusTrack.API.Application.DTOs.Optimization.Request
{
    public class Root
    {
        public List<Job> jobs { get; set; } = new List<Job>();
        public List<Vehicle> vehicles { get; set; } = new List<Vehicle>();
    }
}
