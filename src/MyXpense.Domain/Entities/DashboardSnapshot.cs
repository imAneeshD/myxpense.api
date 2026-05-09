using System;
using MyXpense.Domain.Common;

namespace MyXpense.Domain.Entities;

public class DashboardSnapshot : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public string SnapshotMonth { get; set; } = string.Empty; // e.g., 2026-05
    public decimal TotalExpense { get; set; }
    public decimal TotalIncome { get; set; }
    public string? HighestExpenseCategory { get; set; }
    public decimal AverageDailySpend { get; set; }

    public User User { get; set; } = null!;
}
