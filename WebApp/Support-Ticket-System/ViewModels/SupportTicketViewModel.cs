using System;
using System.Collections.Generic;

namespace Support_Ticket_System.ViewModels
{
    public class SupportTicketViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }  // Assuming you want to show username instead of full User object

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ClosedAt { get; set; }

        // Nested collections (simplified versions)
        public List<TicketReplyViewModel> Replies { get; set; }

        public List<AttachmentViewModel> Attachments { get; set; }

        public List<string> Tags { get; set; }  // Just tag names

        public List<AIResponseViewModel> AIResponses { get; set; }
    }

    public class TicketReplyViewModel
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Comment { get; set; }
        public string RepliedByUserName { get; set; }
        public DateTime RepliedOn { get; set; }
    }

    public class AttachmentViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }  // URL or path to the attachment
    }

    public class AIResponseViewModel
    {
        public int Id { get; set; }
        public string ResponseText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
