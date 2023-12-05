using ABB.Interview.API.DeviceGroups.Managers.Interfaces;
using ABB.Interview.API.DeviceGroups.Models;
using ABB.Interview.API.Services.Interfaces;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;

namespace ABB.Interview.API.DeviceGroups.Controllers;

[ApiController]
[Route("api/groups")]
public class DeviceGroupController : ControllerBase
{
    private readonly ILogger<DeviceGroupController> _logger;
    private readonly IDataHandlerService _service;
    private readonly IDeviceGroupManager _manager;

    public DeviceGroupController(
        ILogger<DeviceGroupController> logger,
        IDeviceGroupManager manager,
        IDataHandlerService service)
    {
        Guard.Against.Null(logger);
        Guard.Against.Null(service);
        Guard.Against.Null(manager);

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
            List<DeviceGroupListModel> response = await _manager.HandleDeviceGroups(measurements);
        }
        catch (Exception)
        {

            throw;
        }

        return Ok(Array.Empty<DeviceGroupListModel>());
    }
}