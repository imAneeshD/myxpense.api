using System;

namespace MyXpense.Application.Features.Expenses.DTOs;

public class ExpenseDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TagId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string? PaymentMethod { get; set; }
    public bool IsRecurring { get; set; }
    public string TagName { get; set; } = string.Empty;
}
