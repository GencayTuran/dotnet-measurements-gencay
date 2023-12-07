using ABB.Interview.API.DeviceGroups.Managers;
using ABB.Interview.API.DeviceGroups.Models;
using ABB.Interview.API.Devices.Managers.Interfaces;
using ABB.Interview.API.Devices.Models;
using ABB.Interview.API.Measurements.Models;
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
        public async Task<List<DeviceListModel>> ManageDeviceList()
        {
            List<DeviceListModel> deviceList = new();

            _logger.LogInformation("Retrieving measurements from file.");
            List<MeasurementModel> retrievedMeasurements = await _service.RetrieveData();
            if (!retrievedMeasurements.Any())
            {
                throw new Exception($"Measurement data is empty. No data to retrieve into {nameof(DeviceGroupManager)}.");
            }

            _logger.LogInformation("Mapping measurements into dictionary.");
            Dictionary<string, MeasurementModel> measurementsDict = await _service.DataToDictionary(retrievedMeasurements);

            _logger.LogInformation("Listing devices.");
            deviceList = measurementsDict.Select(model => new DeviceListModel()
            {
                DeviceId = model.Value.ResourceId,
                Group = model.Value.DeviceGroup,
                Direction = model.Value.Direction,
                MaxPower = model.Value.Power.Max(x => x.Max)
            }).OrderBy(x => x.Group).ThenBy(x => x.Direction).ThenBy(x => x.MaxPower)
                .ToList();

            return deviceList;
        }
    }
}
