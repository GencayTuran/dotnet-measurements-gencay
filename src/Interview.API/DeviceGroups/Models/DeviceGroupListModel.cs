namespace ABB.Interview.API.DeviceGroups.Models;

public class DeviceGroupListModel
{
    private double _power;
    public string? Group { get; set; }
    public string? Direction { get; set; }
    public double Power 
    {
        get => _power;
        set => _power = Math.Round(value, 4);
    }
}