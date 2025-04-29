namespace PlusTrack.API.Application.DTOs.Optimization.Response
{
    public class VroomResponseStep
    {
        public string type { get; set; }
        public List<double> location { get; set; }
        public int? id { get; set; }
    }
}
