using Microsoft.AspNetCore.Mvc;
using Support_Ticket_System.Data;
using Support_Ticket_System.Models;
using Support_Ticket_System.ViewModels;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Support_Ticket_System.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace Support_Ticket_System.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IJwtService _jwt;

        public AuthController(AppDbContext context, IJwtService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (await _context.Users.AnyAsync(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Email already registered.");
                return View(model);
            }

            var user = new User
            {
                Email = model.Email,
                FullName = model.FullName,
                PasswordHash = HashPassword(model.Password),
                Role = "User"
            };

            _context.Users.Add(user);
           var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            ModelState.AddModelError(string.Empty, "Inavlid LoginAttemnt");

            return View(model);

        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var hashed = HashPassword(model.Password);

            var user = await _context.Users.FirstOrDefaultAsync(u =>
                u.Email == model.Email && u.PasswordHash == hashed);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            var token = _jwt.GenerateToken(user.Email, user.Role);
            ViewBag.Token = token;
            if (user!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Inavlid LoginAttemnt");

            return View(model);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}

