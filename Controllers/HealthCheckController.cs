using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TraineeManagement.Controllers;

[ApiController]
[Route("/api/health")]
public class HealthCheckController : ControllerBase
{

    private readonly HealthCheckService _healthCheckService;

    public HealthCheckController(HealthCheckService healthCheckService)
    {
        _healthCheckService = healthCheckService;
    }


    [HttpGet("live")]
    public async Task<IActionResult> GetLive()
    {
        HealthReport report = await _healthCheckService.CheckHealthAsync();
        var response = new
        {
            status = report.Status.ToString(),
            application = "Trainee Management API",
            timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")
        };

        return Ok(response);
    }

    [HttpGet("ready")]
    public async Task<IActionResult> GetReady()
    {
        HealthReport report = await _healthCheckService.CheckHealthAsync();

        IEnumerable servicesStatus = report.Entries.Select(entry => new
        {
            Service = entry.Key,
            Status = entry.Value.Status.ToString()
        });

        var response = new
        {
            OverallStatus = report.Status.ToString(),
            TotalDuration = report.TotalDuration,
            Services = servicesStatus
        };
        return Ok(response);
    }
}
