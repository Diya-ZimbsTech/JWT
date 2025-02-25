namespace ClaimBasedAuth.Models
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Admin" or "User"
        public List<string> Permissions { get; set; } = new List<string>(); // List of user permissions
    }
}
