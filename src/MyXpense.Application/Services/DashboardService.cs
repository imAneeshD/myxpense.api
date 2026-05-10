using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyXpense.Application.Common.Interfaces;

namespace MyXpense.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IApplicationDbContext _context;

    public DashboardService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<object> GetMonthlyTotalAsync(Guid userId, CancellationToken cancellationToken)
    {
        var startOfMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
        var total = await _context.Expenses
            .Where(e => e.UserId == userId && e.ExpenseDate >= startOfMonth)
            .SumAsync(e => e.Amount, cancellationToken);

        return new { Total = total, Month = startOfMonth.ToString("MMMM yyyy") };
    }

    public async Task<object> GetWeeklyTotalAsync(Guid userId, CancellationToken cancellationToken)
    {
        var startOfWeek = DateTime.UtcNow.AddDays(-(int)DateTime.UtcNow.DayOfWeek);
        var total = await _context.Expenses
            .Where(e => e.UserId == userId && e.ExpenseDate >= startOfWeek)
            .SumAsync(e => e.Amount, cancellationToken);

        return new { Total = total, WeekStarting = startOfWeek.ToShortDateString() };
    }

    public async Task<object> GetCategoryBreakdownAsync(Guid userId, CancellationToken cancellationToken)
    {
        var breakdown = await _context.Expenses
            .Where(e => e.UserId == userId)
            .Include(e => e.Category)
            .GroupBy(e => e.Category.Name)
            .Select(g => new
            {
                Category = g.Key,
                Total = g.Sum(e => e.Amount)
            })
            .ToListAsync(cancellationToken);

        return breakdown;
    }
}
