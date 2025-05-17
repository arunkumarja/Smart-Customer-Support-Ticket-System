using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Support_Ticket_System.Models
{
    public class SupportTicket
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "Open";

        [MaxLength(20)]
        public string Priority { get; set; } = "Medium";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ClosedAt { get; set; }

        public ICollection<TicketReply> Replies { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<TicketTag> TicketTags { get; set; }
        public ICollection<AIResponseLog> AIResponses { get; set; }
    }
}
