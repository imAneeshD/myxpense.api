using System;
using MyXpense.Domain.Common;

namespace MyXpense.Domain.Entities;

public class Expense : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? GroupId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string? PaymentMethod { get; set; }
    public bool IsRecurring { get; set; }

    public User User { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public Group? Group { get; set; }
}
