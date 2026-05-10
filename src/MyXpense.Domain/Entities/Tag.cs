using System;
using System.Collections.Generic;
using MyXpense.Domain.Common;

namespace MyXpense.Domain.Entities;

public class Tag : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public Guid? GroupId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Color { get; set; }
    public string? Icon { get; set; }

    public User User { get; set; } = null!;
    public Group? Group { get; set; }
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
