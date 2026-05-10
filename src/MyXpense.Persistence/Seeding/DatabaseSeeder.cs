using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyXpense.Domain.Entities;
using MyXpense.Persistence.Contexts;

namespace MyXpense.Persistence.Seeding;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Seed default admin user
        if (!await context.Users.AnyAsync(u => u.Email == "admin@myxpense.com"))
        {
            var adminUser = new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                FullName = "Admin User",
                Email = "admin@myxpense.com",
                PasswordHash = "admin@123", // In real app, hash this!
                Currency = "USD",
                TimeZone = "UTC",
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "System"
            };

            context.Users.Add(adminUser);
            await context.SaveChangesAsync();

            // Seed default categories for the admin user
            var defaultCategories = new List<Category>
            {
                new Category { Name = "Groceries", Color = "#FF5733", Icon = "shopping_cart", UserId = adminUser.Id, CreatedDate = DateTime.UtcNow, CreatedBy = "System" },
                new Category { Name = "Rent", Color = "#33FF57", Icon = "home", UserId = adminUser.Id, CreatedDate = DateTime.UtcNow, CreatedBy = "System" },
                new Category { Name = "Bills", Color = "#3357FF", Icon = "receipt", UserId = adminUser.Id, CreatedDate = DateTime.UtcNow, CreatedBy = "System" },
                new Category { Name = "Travel", Color = "#F333FF", Icon = "flight", UserId = adminUser.Id, CreatedDate = DateTime.UtcNow, CreatedBy = "System" }
            };

            context.Categories.AddRange(defaultCategories);
            await context.SaveChangesAsync();
        }
    }
}
