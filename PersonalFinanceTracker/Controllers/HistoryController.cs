using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.Data;
using System.Security.Claims;

[Authorize]
public class HistoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public HistoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

        var expenses = _context.Expenses
            .Where(e => e.UserId == userId)
            .OrderByDescending(e => e.Date)
            .ToList();

        var incomes = _context.Incomes
            .Where(i => i.UserId == userId)
            .OrderByDescending(i => i.Date)
            .ToList();

        var budgets = _context.Budgets
            .Where(b => b.UserId == userId)
            .OrderByDescending(b => b.Month)
            .ToList();

        return View(Tuple.Create(expenses, incomes, budgets));
    }
}
