namespace Support_Ticket_System.Services
{
    public interface IJwtService
    {
        string GenerateToken(string email, string role);
    }
}
