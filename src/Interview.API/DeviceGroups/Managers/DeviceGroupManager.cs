using ABB.Interview.API.DeviceGroups.Managers.Interfaces;
using ABB.Interview.API.DeviceGroups.Models;

namespace ABB.Interview.API.DeviceGroups.Managers
{
    public class DeviceGroupManager : IDeviceGroupManager
    {
        public DeviceGroupManager() { }

        public Task<List<DeviceGroupListModel>> HandleDeviceGroups(Dictionary<string, Dictionary<string, string>> measurements)
        {
            throw new NotImplementedException();
        }
    }
}
