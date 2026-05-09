using System;
using MyXpense.Domain.Common;

namespace MyXpense.Domain.Entities;

public class RecurringExpense : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public Guid TagId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public string Frequency { get; set; } = string.Empty; // e.g., Monthly, Weekly
    public DateTime StartDate { get; set; }
    public DateTime? NextExecutionDate { get; set; }
    public bool AutoCreateExpense { get; set; }
    public bool IsActive { get; set; } = true;

    public User User { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}
