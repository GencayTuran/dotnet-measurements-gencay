namespace ABB.Interview.API.DeviceGroups.Models
{
    public class TotalPowerModel
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public double Avg { get; set; }

        public TotalPowerModel(double min, double max, double avg)
        {
            Min = Math.Round(min, 4);
            Max = Math.Round(max, 4);
            Avg = Math.Round(avg, 4);
        }
    }
}
