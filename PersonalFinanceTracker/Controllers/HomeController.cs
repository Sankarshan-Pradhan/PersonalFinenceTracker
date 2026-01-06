using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;  // Add this for [Authorize]
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.Models;

namespace PersonalFinanceTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: / (Public home page - no changes needed)
        public IActionResult Index()
        {
            return View();
        }

        // NEW: GET: /Home/Dashboard (Protected dashboard for logged-in users)
        // - Requires authentication; redirects to login if not logged in
        // - Use this as the main app interface (e.g., add navigation links to Expense/Income/Budget controllers)
        [Authorize]
        public IActionResult Dashboard()
        {
            // Optional: Add logic here later (e.g., fetch user stats from database via ApplicationDbContext)
            return View();  // Renders Views/Home/Dashboard.cshtml
        }

        // REMOVED: Privacy() - Not needed for the finance tracker; delete this action and its view if you don't plan to use it

        // Error handling - no changes needed
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}