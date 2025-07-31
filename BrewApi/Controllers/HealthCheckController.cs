using Microsoft.AspNetCore.Mvc;

namespace BrewApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCheckController(): ControllerBase
{
    [HttpGet("ping", Name = "Ping")]
    public IActionResult Get()
    {
        return Ok("Test");
    }
}