using ClaimBasedAuth.Models;

namespace ClaimBasedAuth.Interfaces
{
    public interface IUserService
    {
        Task<User?> AuthenticateUser(string username, string password);
    }
}
