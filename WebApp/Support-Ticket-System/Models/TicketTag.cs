namespace Support_Ticket_System.Models
{
    public class TicketTag
    {
        public int TicketId { get; set; }
        public SupportTicket Ticket { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
