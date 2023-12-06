using ABB.Interview.API.DeviceGroups.Managers;
using ABB.Interview.API.Devices.Managers.Interfaces;
using ABB.Interview.API.Devices.Models;
using ABB.Interview.API.Services.Interfaces;
using Ardalis.GuardClauses;

namespace ABB.Interview.API.Devices.Managers
{
    public class DeviceListManager : IDeviceListManager
    {
        private readonly ILogger<DeviceListManager> _logger;
        private readonly IDataHandlerService _service;

        public DeviceListManager(
            ILogger<DeviceListManager> logger,
            IDataHandlerService service)
        {
            Guard.Against.Null(logger);
            Guard.Against.Null(service);

            _logger = logger;
            _service = service;
        }
        public Task<List<DeviceListModel>> HandleDevices()
        {
            throw new NotImplementedException();
        }
    }
}
