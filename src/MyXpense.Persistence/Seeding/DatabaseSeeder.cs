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
                Id = Guid.NewGuid(),
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

            // Seed default tags for the admin user
            var defaultTags = new List<Tag>
            {
                new Tag { Name = "Groceries", Color = "#FF5733", Icon = "shopping_cart", UserId = adminUser.Id, CreatedDate = DateTime.UtcNow, CreatedBy = "System" },
                new Tag { Name = "Rent", Color = "#33FF57", Icon = "home", UserId = adminUser.Id, CreatedDate = DateTime.UtcNow, CreatedBy = "System" },
                new Tag { Name = "Bills", Color = "#3357FF", Icon = "receipt", UserId = adminUser.Id, CreatedDate = DateTime.UtcNow, CreatedBy = "System" },
                new Tag { Name = "Travel", Color = "#F333FF", Icon = "flight", UserId = adminUser.Id, CreatedDate = DateTime.UtcNow, CreatedBy = "System" }
            };

            context.Tags.AddRange(defaultTags);
            await context.SaveChangesAsync();
        }
    }
}
