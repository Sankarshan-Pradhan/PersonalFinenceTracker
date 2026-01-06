using Microsoft.AspNetCore.Authorization;  // For [Authorize]
using Microsoft.AspNetCore.Mvc;  // For IActionResult
using PersonalFinanceTracker.Data;  // For ApplicationDbContext
using PersonalFinanceTracker.Models;  // For Expense model
using System.Linq;  // For LINQ queries
using System.Security.Claims;  // For User claims

[Authorize]  // All actions in this controller require login
public class ExpenseController : Controller
{
    private readonly ApplicationDbContext _context;

    // Constructor: Dependency injection provides ApplicationDbContext
    public ExpenseController(ApplicationDbContext context)
    {
        _context = context;
    }

   

    // GET: /Expense/Create (Show form to add a new expense)
    public IActionResult Create()
    {
        return View();  // Renders Views/Expense/Create.cshtml (empty form)
    }

    // POST: /Expense/Create (Process form submission and save to database)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Expense expense)
    {
        // Set UserId before validation
        expense.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (ModelState.IsValid)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(expense);
    }

    // Add similar actions for Edit, Delete, etc. (e.g., GET/POST for editing/deleting expenses)
    // Example: GET /Expense/Edit/5 (fetch and show edit form)
    // Example: POST /Expense/Edit/5 (update in database)
    // Example: GET/POST /Expense/Delete/5 (confirm and delete)
    // For each, include ownership checks: if (expense.UserId != userId) return NotFound();

    // GET: /Expense/Index (Expense History with search & filter)
    public IActionResult Index(string search, DateTime? fromDate, DateTime? toDate)
    {
        // Get logged-in user's ID
        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

        // Base query (IMPORTANT: IQueryable for filters)
        var expenses = _context.Expenses
            .Where(e => e.UserId == userId)
            .AsQueryable();

        // 🔍 Search by category or description
        if (!string.IsNullOrWhiteSpace(search))
        {
            expenses = expenses.Where(e =>
                e.Category.Contains(search) ||
                e.Description.Contains(search));
        }

        // 📅 Filter by date range
        if (fromDate.HasValue)
        {
            expenses = expenses.Where(e => e.Date >= fromDate.Value);
        }

        if (toDate.HasValue)
        {
            expenses = expenses.Where(e => e.Date <= toDate.Value);
        }

        // ⬇ Sort by date (newest first)
        expenses = expenses.OrderByDescending(e => e.Date);

        return View(expenses.ToList());
    }

}