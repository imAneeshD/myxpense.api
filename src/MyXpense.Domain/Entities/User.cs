using System.Collections.Generic;
using MyXpense.Domain.Common;

namespace MyXpense.Domain.Entities;

public class User : BaseAuditableEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? Currency { get; set; }
    public string? TimeZone { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    public ICollection<RecurringExpense> RecurringExpenses { get; set; } = new List<RecurringExpense>();
}
