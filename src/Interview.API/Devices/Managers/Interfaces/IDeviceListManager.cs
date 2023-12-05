using ABB.Interview.API.Devices.Models;

namespace ABB.Interview.API.Devices.Managers.Interfaces
{
    public interface IDeviceListManager
    {
        Task<List<DeviceListModel>> HandleDevices(Dictionary<string,Dictionary<string,string>> measurements);
    }
}