using Microsoft.AspNetCore.Mvc;

namespace Support_Ticket_System.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
