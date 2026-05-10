using System.Collections.Generic;

namespace MyXpense.Application.Features.Dashboard.DTOs;

public class DashboardDto
{
    public decimal MonthlyTotal { get; set; }
    public decimal WeeklyTotal { get; set; }
    public List<CategoryBreakdownDto> CategoryBreakdown { get; set; } = new();
}

public class CategoryBreakdownDto
{
    public string Category { get; set; } = string.Empty;
    public decimal Total { get; set; }
}
