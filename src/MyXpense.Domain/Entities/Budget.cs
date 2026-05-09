using System;
using MyXpense.Domain.Common;

namespace MyXpense.Domain.Entities;

public class Budget : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public Guid TagId { get; set; }
    public string BudgetName { get; set; } = string.Empty;
    public decimal MonthlyLimit { get; set; }
    public int StartMonth { get; set; }
    public bool IsActive { get; set; } = true;

    public User User { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}
