using System;

namespace MyXpense.Application.Features.Budgets.DTOs;

public class BudgetDto
{
    public Guid Id { get; set; }
    public string BudgetName { get; set; } = string.Empty;
    public decimal MonthlyLimit { get; set; }
    public int StartMonth { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
