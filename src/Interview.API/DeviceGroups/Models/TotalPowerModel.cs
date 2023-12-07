namespace ABB.Interview.API.DeviceGroups.Models
{
    public class TotalPowerModel
    {
        private double _min;
        private double _max;
        private double _avg;

        public double Min
        {
            get => _min;
            set => _min = Math.Round(value, 4);
        }

        public double Max
        {
            get => _max;
            set => _max = Math.Round(value, 4);
        }

        public double Avg
        {
            get => _avg;
            set => _avg = Math.Round(value, 4);
        }
    }

}
