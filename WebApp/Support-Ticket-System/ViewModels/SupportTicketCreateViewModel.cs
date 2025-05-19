using System.ComponentModel.DataAnnotations;

namespace Support_Ticket_System.ViewModels
{

        public class SupportTicketCreateViewModel
        {
            [Required, MaxLength(255)]
            public string Title { get; set; }

            public string Description { get; set; }

            [MaxLength(20)]
            public string Priority { get; set; } 
        }

    
}
