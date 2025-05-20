using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Support_Ticket_System.Data;
using Support_Ticket_System.Models;
using Support_Ticket_System.ViewModels;
using System.Security.Claims;

namespace Support_Ticket_System.Controllers
{
    //[Authorize]
    public class TicketsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userEmail = User.Identity.Name;
            var tickets = await _context.SupportTickets
                .Where(t => t.User.Email == userEmail)
                .ToListAsync();

            return View(tickets);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(SupportTicketCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            var ticket = new SupportTicket
            {
                UserId = userId,
                Title = model.Title,
                Description = model.Description,
                Priority = model.Priority,
                Status = "Open",
                CreatedAt = DateTime.UtcNow
            };

            _context.SupportTickets.Add(ticket);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }

}


