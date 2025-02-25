using ClaimBasedAuth.Context;
using ClaimBasedAuth.Interfaces;
using ClaimBasedAuth.Models;
using ClaimBasedAuth.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClaimBasedAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService us;
        private readonly ITokenService ts;
        private readonly AppDbContext context;

        public AuthController(IUserService us,ITokenService ts , AppDbContext context)
        {
            this.us = us;
            this.ts = ts;
            this.context = context;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Models.RegisterRequest request)
        {
            if (await context.Users.AnyAsync(u => u.Username == request.Username))
            {
                return BadRequest("Username already exists.");
            }

            var newUser = new User
            {
                Username = request.Username,
                PasswordHash = request.Password,  // Store hashed password in real-world apps!
                Role = request.Role, // Assign user role (e.g., Admin, User)
                Claims = request.Permissions.Select(c => new UserClaim { ClaimType = "Permission", ClaimValue = c }).ToList()
            };

            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully." });
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Models.LoginRequest request)
        {
            var user = await us.AuthenticateUser(request.Username, request.Password);
            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = ts.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}
