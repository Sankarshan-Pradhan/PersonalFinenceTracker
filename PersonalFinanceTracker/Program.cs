using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Data;  // Add this: Namespace for ApplicationDbContext
using PersonalFinanceTracker.Models;  // Add this: Namespace for ApplicationUser

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register ApplicationDbContext with SQL Server (enables EF Core for database operations)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure ASP.NET Core Identity for user authentication and authorization
// - Uses ApplicationUser (your custom model extending IdentityUser)
// - RequireConfirmedAccount = true: Forces email verification for new users (enhances security; can be disabled for testing)
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();  // Stores user data in your ApplicationDbContext (e.g., AspNetUsers table)

// Add MVC services (enables controllers, views, and model binding for web requests)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline (middleware that processes requests)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");  // In production, show a custom error page on exceptions
    app.UseHsts();  // Enforce HTTPS for security
}

app.UseHttpsRedirection();  // Redirect HTTP requests to HTTPS
app.UseStaticFiles();  // Serve static files (e.g., CSS/JS from wwwroot folder)

app.UseRouting();  // Enable URL routing (maps URLs to controllers/actions)

app.UseAuthentication();  // Enable user authentication (checks login status; must come before UseAuthorization)
app.UseAuthorization();  // Enable authorization (checks permissions for protected actions)

// Define the default route: If no specific route matches, go to HomeController.Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // e.g., /Expense/Create maps to ExpenseController.Create

// Map Razor Pages (required for Identity's built-in UI, e.g., login/register pages)
app.MapRazorPages();

app.Run();  // Start the web server and listen for requests