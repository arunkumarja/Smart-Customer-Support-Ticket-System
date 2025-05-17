using Microsoft.EntityFrameworkCore;
using Support_Ticket_System.Models;

namespace Support_Ticket_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<SupportTicket> SupportTickets { get; set; }
        public DbSet<TicketReply> TicketReplies { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<JwtToken> JwtTokens { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TicketTag> TicketTags { get; set; }
        public DbSet<AIResponseLog> AIResponseLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key for many-to-many TicketTag
            modelBuilder.Entity<TicketTag>()
                .HasKey(tt => new { tt.TicketId, tt.TagId });

            // Relationships can be further configured here if needed
        }
    }
}
