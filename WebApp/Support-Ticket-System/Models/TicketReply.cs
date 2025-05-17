using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Support_Ticket_System.Models
{
    public class TicketReply
    {
        public int Id { get; set; }

        [ForeignKey("SupportTicket")]
        public int TicketId { get; set; }
        public SupportTicket SupportTicket { get; set; }

        [MaxLength(50)]
        public string Sender { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Attachment> Attachments { get; set; }
    }
}
