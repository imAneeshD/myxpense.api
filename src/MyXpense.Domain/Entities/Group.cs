using System;
using System.Collections.Generic;
using MyXpense.Domain.Common;

namespace MyXpense.Domain.Entities;

public class Group : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid OwnerId { get; set; }
    
    public User Owner { get; set; } = null!;
    public ICollection<User> Members { get; set; } = new List<User>();
    public ICollection<Category> Categories { get; set; } = new List<Category>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
