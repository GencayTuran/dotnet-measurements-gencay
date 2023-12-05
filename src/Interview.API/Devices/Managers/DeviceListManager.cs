using ABB.Interview.API.Devices.Managers.Interfaces;
using ABB.Interview.API.Devices.Models;

namespace ABB.Interview.API.Devices.Managers
{
    public class DeviceListManager : IDeviceListManager
    {
        public Task<List<DeviceListModel>> HandleDevices(Dictionary<string, Dictionary<string, string>> measurements)
        {
            throw new NotImplementedException();
        }
    }
}
