using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    // Only users with the "Admin" role can access this endpoint
    [HttpGet("admin-panel")]
    [Authorize(Policy = "AdminOnly")]
    public IActionResult AdminPanel()
    {
        return Ok("Welcome to the Admin Panel!");
    }

    // Retrieve all claims of the logged-in user
    [HttpGet("myclaims")]
    [Authorize]
    public IActionResult GetMyClaims()
    {
        var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
        return Ok(claims);
    }
}
