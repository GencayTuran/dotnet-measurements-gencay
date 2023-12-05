using ABB.Interview.API.DeviceGroups.Managers.Interfaces;
using ABB.Interview.API.DeviceGroups.Models;
using ABB.Interview.API.Devices.Managers.Interfaces;
using ABB.Interview.API.Devices.Models;
using ABB.Interview.API.Services.Interfaces;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;

namespace ABB.Interview.API.Devices.Controllers;

[ApiController]
[Route("api/devices")]
public class DeviceController : ControllerBase
{
    private readonly ILogger<DeviceController> _logger;
    private readonly IDataHandlerService _service;
    private readonly IDeviceListManager _manager;

    public DeviceController(
        ILogger<DeviceController> logger,
        IDataHandlerService service,
        IDeviceListManager manager)
    {
        Guard.Against.Null(logger);
        Guard.Against.Null(logger);
        Guard.Against.Null(logger);

        _logger = logger;
        _service = service;
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);

        try
        {
            var measurements = await _service.RetrieveData();
            List<DeviceListModel> response = await _manager.HandleDevices(measurements);
        }
        catch (Exception)
        {

            throw;
        }

        return Ok(Array.Empty<DeviceListModel>());
    }
}