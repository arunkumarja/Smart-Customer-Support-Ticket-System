using System.ComponentModel.DataAnnotations.Schema;

namespace Support_Ticket_System.Models
{
    public class JwtToken
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsRevoked { get; set; } = false;
    }
}
