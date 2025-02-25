using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/dashboard")]
[ApiController]
public class DashboardController : ControllerBase
{
    // This endpoint requires the "CanViewReports" claim
    [HttpGet("reports")]
    [Authorize(Policy = "CanViewReports")]
    public IActionResult ViewReports()
    {
        return Ok("You have access to view reports!");
    }
}
