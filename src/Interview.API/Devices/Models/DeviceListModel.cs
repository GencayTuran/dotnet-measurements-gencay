namespace ABB.Interview.API.Devices.Models;

public class DeviceListModel
{
    private double _maxPower;
    public string? DeviceId { get; set; }
    public string? Group { get; set; }
    public string? Direction { get; set; }
    public double MaxPower
    {
        get => _maxPower;
        set => _maxPower = Math.Round(value, 4);
    }
}