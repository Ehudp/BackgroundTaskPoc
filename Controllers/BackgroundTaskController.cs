using BackgroundTaskPoc.Data;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundTaskPoc.Controllers;

[ApiController]
[Route("[controller]")]
public class BackgroundTaskController : ControllerBase
{
    private readonly ILogger<BackgroundTaskController> _logger;
    private readonly HostedServiceSampleData _hostedServiceSampleData;

    private readonly BackgroundServiceSampleData _backgroundServiceSampleData;


    public BackgroundTaskController(ILogger<BackgroundTaskController> logger,
                                    HostedServiceSampleData hostedServiceSampleData, BackgroundServiceSampleData backgroundServiceSampleData)
    {
        _logger = logger;
        _hostedServiceSampleData = hostedServiceSampleData;
        _backgroundServiceSampleData = backgroundServiceSampleData;
    }

    [HttpGet("HostedService")]
    public IEnumerable<string> GetHostedService()
    {
        return _hostedServiceSampleData.Data.OrderBy(item => item).TakeLast(10);
    }

    [HttpGet("BackgroundService")]
    public IEnumerable<string> GetBackgroundService()
    {
        return _backgroundServiceSampleData.Data.OrderBy(item => item).TakeLast(10);
    }
}
