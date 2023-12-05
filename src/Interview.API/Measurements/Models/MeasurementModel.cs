namespace ABB.Interview.API.Measurements.Models
{
    public class MeasurementModel
    {
        public string ResourceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceGroup { get; set; }
        public string Direction { get; set; }
        public List<PowerListModel> Power { get; set; }
    }
}
