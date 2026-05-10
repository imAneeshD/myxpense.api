using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyXpense.Application.Common.Interfaces;
using MyXpense.Domain.Entities;

namespace MyXpense.API.BackgroundServices;

public class RecurringExpenseWorker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RecurringExpenseWorker> _logger;

    public RecurringExpenseWorker(IServiceProvider serviceProvider, ILogger<RecurringExpenseWorker> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Recurring Expense Worker is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Checking for recurring expenses...");

            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
                
                var now = DateTime.UtcNow;
                var pendingExpenses = context.RecurringExpenses
                    .Where(r => r.IsActive && r.AutoCreateExpense && (r.NextExecutionDate == null || r.NextExecutionDate <= now))
                    .ToList();

                foreach (var recurring in pendingExpenses)
                {
                    _logger.LogInformation("Creating expense for recurring item: {Title}", recurring.Title);

                    var expense = new Expense
                    {
                        UserId = recurring.UserId,
                        CategoryId = recurring.CategoryId,
                        Title = recurring.Title,
                        Description = recurring.Description,
                        Amount = recurring.Amount,
                        ExpenseDate = now,
                        IsRecurring = true
                    };

                    context.Expenses.Add(expense);
                    
                    // Update next execution date based on frequency (simplified)
                    recurring.NextExecutionDate = recurring.Frequency.ToLower() switch
                    {
                        "daily" => now.AddDays(1),
                        "weekly" => now.AddDays(7),
                        "monthly" => now.AddMonths(1),
                        _ => now.AddMonths(1)
                    };
                }

                if (pendingExpenses.Any())
                {
                    await context.SaveChangesAsync(stoppingToken);
                }
            }

            await Task.Delay(TimeSpan.FromHours(1), stoppingToken); // Check every hour
        }

        _logger.LogInformation("Recurring Expense Worker is stopping.");
    }
}
