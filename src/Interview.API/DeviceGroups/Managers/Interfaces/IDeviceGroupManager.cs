using ABB.Interview.API.DeviceGroups.Models;
using ABB.Interview.API.Devices.Models;

namespace ABB.Interview.API.DeviceGroups.Managers.Interfaces
{
    public interface IDeviceGroupManager
    {
        Task<List<DeviceGroupListModel>> HandleDeviceGroups(Dictionary<string, Dictionary<string, string>> measurements);
    }
}