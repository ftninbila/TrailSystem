using TrailSystem.Models;
using TrailSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace TrailSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Comp2001malFnabillabintizaidiContext _context;

        public HomeController(ILogger<HomeController> logger, Comp2001malFnabillabintizaidiContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterTest user)
        {
            // Check if the username already exists
            var existingName = _context.Users.Any(u => u.Name == user.Name);
            if (existingName)
            {
                ModelState.AddModelError("Name", "Name already exists");
            }

            // Check if the email already exists
            var existingEmail = _context.Users.Any(u => u.Email == user.Email);
            if (existingEmail)
            {
                ModelState.AddModelError("Email", "Email already exists");
            }

            // If there are model state errors, return to the view with errors
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            // Execute the stored procedure
            _context.Database.ExecuteSqlRaw("EXEC dbo.InsertUserProfile @Username, @Password, @Email, @ArchiveStatus",
                new SqlParameter("@Name", user.Name),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@ArchiveStatus", user.ArchiveStatus));

            // Fetch the inserted user
            var insertedUser = _context.Users.FirstOrDefault(u => u.Name == user.Name);

            if (insertedUser == null)
            {
                ModelState.AddModelError(string.Empty, "SignIn failed");
                return View(user);
            }

            return Ok(new { Message = "Login successful", User = user });
        }



        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginTest loginRequest)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u =>
                u.Name == loginRequest.Username && u.Password == loginRequest.Password);

            if (user == null)
            {
                return BadRequest(new { Message = "Invalid username or password" });
            }

            // You can generate and return a JWT token for authentication here if needed

            return Ok(new { Message = "Login successful", User = user });
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
