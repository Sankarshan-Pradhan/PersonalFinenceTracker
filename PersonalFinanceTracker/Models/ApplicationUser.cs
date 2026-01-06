using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace PersonalFinanceTracker.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Example custom fields (add as needed)
        public string? FullName { get; set; }  // Optional: User's full name
        public DateTime? DateOfBirth { get; set; }  // Optional: For age-based features

        // Navigation properties for related entities (EF Core will handle foreign keys)
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Income> Income { get; set; }
        public ICollection<Budget> Budgets { get; set; }
    }
}
