using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyXpense.Application.Common.Interfaces;

public interface IDashboardService
{
    Task<object> GetMonthlyTotalAsync(Guid userId, CancellationToken cancellationToken);
    Task<object> GetWeeklyTotalAsync(Guid userId, CancellationToken cancellationToken);
    Task<object> GetCategoryBreakdownAsync(Guid userId, CancellationToken cancellationToken);
}
