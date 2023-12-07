namespace ABB.Interview.API.DeviceGroups.Models
{
    public class TotalPowerModel
    {
        private decimal _min;
        private decimal _max;
        private decimal _avg;

        public decimal Min
        {
            get => _min;
            set => _min = Math.Round(value, 4);
        }

        public decimal Max
        {
            get => _max;
            set => _max = Math.Round(value, 4);
        }

        public decimal Avg
        {
            get => _avg;
            set => _avg = Math.Round(value, 4);
        }
    }

}
