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
    private readonly IDeviceGroupManager _manager;

    public DeviceGroupController(
        ILogger<DeviceGroupController> logger,
        IDeviceGroupManager manager)
    {
        Guard.Against.Null(logger);
        Guard.Against.Null(manager);

        _logger = logger;
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);

        try
        {
            List<DeviceGroupListModel> response = await _manager.HandleGroups();
        }
        catch (Exception)
        {

            throw;
        }

        return Ok(Array.Empty<DeviceGroupListModel>());
    }
}