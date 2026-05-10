using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyXpense.Domain.Entities;

namespace MyXpense.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Category> Categories { get; }
    DbSet<Expense> Expenses { get; }
    DbSet<RecurringExpense> RecurringExpenses { get; }
    DbSet<Notification> Notifications { get; }
    DbSet<AlertRule> AlertRules { get; }
    DbSet<Budget> Budgets { get; }
    DbSet<DashboardSnapshot> DashboardSnapshots { get; }
    DbSet<Group> Groups { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
