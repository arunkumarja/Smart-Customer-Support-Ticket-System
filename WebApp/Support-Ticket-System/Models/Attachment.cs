namespace Support_Ticket_System.Models
{
    public class Attachment
    {
        public int Id { get; set; }

        public int? TicketId { get; set; }
        public SupportTicket Ticket { get; set; }

        public int? ReplyId { get; set; }
        public TicketReply Reply { get; set; }

        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}

