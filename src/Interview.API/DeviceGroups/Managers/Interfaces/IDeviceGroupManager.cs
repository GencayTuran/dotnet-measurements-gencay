using ABB.Interview.API.DeviceGroups.Models;
using ABB.Interview.API.Devices.Models;
using ABB.Interview.API.Measurements.Models;

namespace ABB.Interview.API.DeviceGroups.Managers.Interfaces
{
    public interface IDeviceGroupManager
    {
        Task<List<DeviceGroupListModel>> ManageDeviceGroups();
    }
}