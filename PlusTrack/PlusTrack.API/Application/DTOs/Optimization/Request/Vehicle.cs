namespace PlusTrack.API.Application.DTOs.Optimization.Request
{
    public class Vehicle
    {
        public int id { get; set; } = 1;
        public List<double> start { get; set; }
        public List<double> end { get; set; }
        public string profile { get; set; } = "driving-car";

        public Vehicle(List<double> start, List<double> end)
        {
            this.start = start;
            this.end = end;
        }

        public Vehicle()
        {
            List<double> start = new List<double>();
            List<double> end = new List<double>();

            start.Add(2.154007);
            start.Add(41.390205);

            end.Add(2.154007);
            end.Add(41.390205);

            this.start = start;
            this.end = end;
        }
    }
}
