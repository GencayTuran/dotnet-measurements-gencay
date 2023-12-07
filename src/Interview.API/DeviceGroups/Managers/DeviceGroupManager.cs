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
        public async Task<List<DeviceGroupListModel>> ManageDeviceGroups()
        {
            List<DeviceGroupListModel> deviceGroups = new();

            _logger.LogInformation("Retrieving measurements from file.");
            List<MeasurementModel> retrievedMeasurements = await _service.RetrieveData();
            if (!retrievedMeasurements.Any())
            {
                throw new Exception($"Measurement data is empty. No data to retrieve into {nameof(DeviceGroupManager)}.");
            }

            _logger.LogInformation("Mapping measurements into dictionary.");
            Dictionary<string, MeasurementModel> measurementsDict = await _service.DataToDictionary(retrievedMeasurements);

            _logger.LogInformation("Grouping dictionary.");
            deviceGroups =
                measurementsDict.GroupBy(m => new { m.Value.DeviceGroup, m.Value.Direction })
                .Select(model => new DeviceGroupListModel()
                {
                    Group = model.Key.DeviceGroup,
                    Direction = model.Key.Direction,
                    Power = new TotalPowerModel()
                    {
                        Min = model.SelectMany(x => x.Value.Power.Select(p => p.Min)).Sum(),
                        Max = model.SelectMany(x => x.Value.Power.Select(p => p.Max)).Sum(),
                        Avg = model.SelectMany(x => x.Value.Power.Select(p => p.Avg)).Sum()
                    }
                }).ToList();

            return deviceGroups;
        }
    }
}
