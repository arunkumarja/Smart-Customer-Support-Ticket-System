    namespace Support_Ticket_System.Models
{
    public class AIResponseLog
    {
        public int Id { get; set; }

        public int? TicketId { get; set; }
        public SupportTicket Ticket { get; set; }

        public int? ReplyId { get; set; }
        public TicketReply Reply { get; set; }

        public string Prompt { get; set; }
        public string Response { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
