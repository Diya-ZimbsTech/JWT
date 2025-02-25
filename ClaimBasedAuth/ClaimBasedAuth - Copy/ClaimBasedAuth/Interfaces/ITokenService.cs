using ClaimBasedAuth.Models;

namespace ClaimBasedAuth.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
