using System.ComponentModel.DataAnnotations;

namespace ClaimBasedAuth.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required, MaxLength(50)]
        public string Role { get; set; }

        public ICollection<UserClaim> Claims { get; set; } = new List<UserClaim>();
    }
}
