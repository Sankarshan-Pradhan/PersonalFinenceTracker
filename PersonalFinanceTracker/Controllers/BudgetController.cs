using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Models;
using System.Linq;
using System.Security.Claims;

namespace PersonalFinanceTracker.Controllers
{
    [Authorize]
    public class BudgetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BudgetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Budget/Index
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var budgets = _context.Budgets
                .Where(b => b.UserId == userId)
                .ToList();

            return View(budgets);
        }

        // GET: /Budget/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Budget/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Budget budget)
        {
            // SAME AS EXPENSE
            budget.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            // Month safety (Budget version of Date)
            if (budget.Month == default)
                budget.Month = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                _context.Budgets.Add(budget);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(budget);
        }
    }
}
