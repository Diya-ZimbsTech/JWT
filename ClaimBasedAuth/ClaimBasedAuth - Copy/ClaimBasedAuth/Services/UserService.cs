using ClaimBasedAuth.Context;
using ClaimBasedAuth.Interfaces;
using ClaimBasedAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace ClaimBasedAuth.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext context;

        public UserService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<User?> AuthenticateUser(string username, string password)
        {
            var auth = await context.Users
                .Include(u => u.Claims)
                .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);
            return auth;
        }
    }
}
