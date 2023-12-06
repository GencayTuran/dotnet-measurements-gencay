using ABB.Interview.API.DeviceGroups.Controllers;
using ABB.Interview.API.DeviceGroups.Managers.Interfaces;
using ABB.Interview.API.DeviceGroups.Models;
using ABB.Interview.API.Measurements.Models;
using ABB.Interview.API.Services.Interfaces;
using Ardalis.GuardClauses;

namespace ABB.Interview.API.DeviceGroups.Managers
{
    public class DeviceGroupManager : IDeviceGroupManager
    {
        private readonly ILogger<DeviceGroupManager> _logger;
        private readonly IDataHandlerService _service;

        public DeviceGroupManager(
            ILogger<DeviceGroupManager> logger,
            IDataHandlerService service)
        {
            Guard.Against.Null(logger);
            Guard.Against.Null(service);

            _logger = logger;
            _service = service;
        }
        public async Task<List<DeviceGroupListModel>> HandleGroups()
        {
            throw new NotImplementedException();
        }
    }
}
