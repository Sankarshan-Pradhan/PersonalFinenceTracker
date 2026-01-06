# Personal Finance Tracker

## 📌 Overview
The **Personal Finance Tracker** is a web-based application designed to help users manage their income, expenses, and budgets efficiently. The application provides a structured way to track financial activities and gain insights into spending patterns.

This project demonstrates practical implementation of software development concepts such as authentication, CRUD operations, database integration, and clean architecture.

---

## 🎯 Objectives
- Allow users to record and manage income and expenses
- Enable users to set and track budgets
- Provide a clear overview of financial data
- Implement secure user authentication
- Follow clean coding and modular development practices

---

## 🛠️ Technologies Used
- **Backend:** ASP.NET Core MVC  
- **Authentication:** ASP.NET Core Identity  
- **Database:** SQL Server with Entity Framework Core  
- **Frontend:** HTML, CSS, Bootstrap  
- **ORM:** Entity Framework Core  
- **Version Control:** Git & GitHub  

---

## ✨ Features
- User registration and login
- Secure authentication and authorization
- Add, edit, delete income and expense records
- Budget management functionality
- Transaction history tracking
- User-specific data handling
- Clean and responsive UI

---

## 📂 Project Structure
PersonalFinanceTracker/
│
├── Controllers/ # Handles request logic
├── Models/ # Entity and view models
├── Views/ # Razor views (UI)
├── Data/ # Database context
├── wwwroot/ # Static files (CSS, JS)
├── Migrations/ # EF Core migrations
└── Program.cs # Application configuration


---

## ⚙️ Setup Instructions

### Prerequisites
- .NET SDK (6.0 or later)
- SQL Server
- Visual Studio / VS Code

### Steps to Run the Project
1. Clone the repository:
   ```bash
  git clone <your-repo-url>
2. Open the project in Visual Studio
3. Update the database connection string in appsettings.json
4. Apply migrations:
    Update-Database
5. Run the application:
    dotnet run

