using System.ComponentModel.DataAnnotations;

namespace Support_Ticket_System.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<TicketTag> TicketTags { get; set; }
    }
}
