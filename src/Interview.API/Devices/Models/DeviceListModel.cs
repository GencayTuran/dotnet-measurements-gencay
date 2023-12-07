namespace ABB.Interview.API.Devices.Models;

public class DeviceListModel
{
    private decimal _maxPower;
    private string _deviceId;
    
    public string DeviceId
    {
        get => _deviceId;
        set => _deviceId = value.Replace("-", "");
    }
    public string Group { get; set; }
    public string Direction { get; set; }
    public decimal MaxPower
    {
        get => _maxPower;
        set => _maxPower = Math.Round(value, 4);
    }
}