using Microsoft.EntityFrameworkCore;
using UniversityWebApp.Data;
using UniversityWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Create database and seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    
    // Add test data if database is empty
    if (!db.Faculties.Any())
    {
        // 1. Add Faculties
        db.Faculties.AddRange(
            new Faculty { Name = "Факультет информационных технологий", Dean = "Иванов И.И." },
            new Faculty { Name = "Экономический факультет", Dean = "Петров П.П." },
            new Faculty { Name = "Юридический факультет", Dean = "Сидоров С.С." }
        );
        db.SaveChanges();
        
        // 2. Add Groups
        db.Groups.AddRange(
            new Group { Name = "ИТ-101", FacultyId = 1, Year = 2023 },
            new Group { Name = "ИТ-102", FacultyId = 1, Year = 2023 },
            new Group { Name = "ЭК-201", FacultyId = 2, Year = 2022 },
            new Group { Name = "ЭК-202", FacultyId = 2, Year = 2022 },
            new Group { Name = "ЮР-301", FacultyId = 3, Year = 2021 },
            new Group { Name = "ЮР-302", FacultyId = 3, Year = 2021 }
        );
        db.SaveChanges();
        
        // 3. Add Students
        db.Students.AddRange(
            new Student { FirstName = "Алексей", LastName = "Смирнов", BirthDate = new DateTime(2002, 5, 15), GroupId = 1 },
            new Student { FirstName = "Мария", LastName = "Кузнецова", BirthDate = new DateTime(2003, 7, 22), GroupId = 1 },
            new Student { FirstName = "Дмитрий", LastName = "Попов", BirthDate = new DateTime(2001, 3, 10), GroupId = 2 },
            new Student { FirstName = "Анна", LastName = "Васильева", BirthDate = new DateTime(2002, 11, 5), GroupId = 3 },
            new Student { FirstName = "Сергей", LastName = "Петров", BirthDate = new DateTime(2000, 9, 30), GroupId = 4 },
            new Student { FirstName = "Екатерина", LastName = "Иванова", BirthDate = new DateTime(2003, 1, 20), GroupId = 5 },
            new Student { FirstName = "Андрей", LastName = "Соколов", BirthDate = new DateTime(2001, 8, 14), GroupId = 6 }
        );
        db.SaveChanges();
    }
}

app.Run();
