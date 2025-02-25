using System.ComponentModel.DataAnnotations;

namespace ClaimBasedAuth.Models
{
    public class UserClaim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string ClaimType { get; set; }

        [Required]
        public string ClaimValue { get; set; }

        public User User { get; set; }
    }
}
