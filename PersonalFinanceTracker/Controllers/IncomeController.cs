using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Models;
using System.Linq;
using System.Security.Claims;

namespace PersonalFinanceTracker.Controllers
{
    [Authorize]
    public class IncomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Income/Index
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var incomes = _context.Incomes
                .Where(i => i.UserId == userId)
                .OrderByDescending(i => i.Date)
                .ToList();

            return View(incomes);
        }

        // GET: /Income/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Income/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Income income)
        {
            // SAME AS EXPENSE
            income.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            // SAME SAFETY AS EXPENSE DATE
            if (income.Date == default)
                income.Date = DateTime.Now;

            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                _context.Incomes.Add(income);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(income);
        }
    }
}
