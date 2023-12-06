namespace ABB.Interview.API.DeviceGroups.Models;

public class DeviceGroupListModel
{
    public string Group { get; set; }
    public string Direction { get; set; }
    public TotalPowerModel Power { get; set; }
}