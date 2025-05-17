using System.ComponentModel.DataAnnotations;

namespace Support_Ticket_System.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string FullName { get; set; }

        [MaxLength(50)]
        public string Role { get; set; } = "User";

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<SupportTicket> Tickets { get; set; }
        public ICollection<JwtToken> JwtTokens { get; set; }
    }
}
